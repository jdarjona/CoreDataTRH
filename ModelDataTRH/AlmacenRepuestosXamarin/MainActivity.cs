using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using AlmacenRepuestosXamarin.Adapter;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Tesseract;
using Tesseract.Droid;
using RepositoryWebServiceTRH.EmpleadoContext;
using AlmacenRepuestosXamarin.Model;




namespace AlmacenRepuestosXamarin
{
    [Activity(Label = "Almacen Repuestos", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light")]
    public class MainActivity : AppCompatActivity 
    {


        bool indeterminateVisible;
        List<Empleados> empleados=new List<Empleados>();
        Data.AccesoDatos restService = new Data.AccesoDatos();
        //ArrayAdapter adapterEmpleados;
        Adapter.AdapterEmpleados adaptadorEmpleados;
        private Android.Support.V7.Widget.SearchView _searchView;
        //private ArrayAdapter _adapter;

        //private Task<bool> api;

        protected override  void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

          

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

           
            // var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            //ActionBar.Title = "Almacen de Repuestos";
            //
            //SetSupportActionBar(toolbar);
            //SupportActionBar.Title = "Almacen Repuestos";

            ITesseractApi api = new TesseractApi(this, AssetsDeployment.OncePerInitialization);

            fillListView();

        }


        private async void fillListView() {

            empleados = await getEmpleados();
            ListView listViewEmpleados = (ListView)FindViewById(Resource.Id.listEmpleados);
            adaptadorEmpleados = new AdapterEmpleados(this, empleados);
            listViewEmpleados.ItemClick += OnListItemClick;
            listViewEmpleados.Adapter = adaptadorEmpleados;
            
        }
        
        private async Task<List<Empleados>> getEmpleados()
        {
           
            var query=await restService.getEmpleados();
            return query;

        }


        public override  bool OnCreateOptionsMenu(IMenu menu)
        {


            MenuInflater.Inflate(Resource.Menu.buscador, menu);

            var item = menu.FindItem(Resource.Id.action_search);

            var searchView = MenuItemCompat.GetActionView(item);
            _searchView = searchView.JavaCast<Android.Support.V7.Widget.SearchView>();

            
            _searchView.QueryTextChange += (s, e) => adaptadorEmpleados.Filter.InvokeFilter(e.NewText);

            _searchView.QueryTextSubmit += (s, e) =>
            {
                // Handle enter/search button on keyboard here
                Toast.MakeText(this, "Searched for: " + e.Query, ToastLength.Short).Show();
                e.Handled = true;
            };

            //MenuItemCompat.SetOnActionExpandListener(item, new SearchViewExpandListener(adaptadorEmpleados));
            
            return base.OnCreateOptionsMenu(menu);
        }

        private class SearchViewExpandListener
            : Java.Lang.Object, MenuItemCompat.IOnActionExpandListener
        {
            private readonly IFilterable _adapter;

            
            public SearchViewExpandListener(IFilterable adapter)
            {
                _adapter = adapter;
            }

            public bool OnMenuItemActionCollapse(IMenuItem item)
            {
                
                //_adapter.Filter.InvokeFilter("");
                return true;
            }

            public bool OnMenuItemActionExpand(IMenuItem item)
            {
                return true;
            }
        }


        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            //  

            //var listView = (Android.Widget.AbsListView)sender;
            var listView = (Android.Widget.ListView)e.Parent;
            var adapter = (AdapterEmpleados)listView.Adapter;

          

            
            //var lista = new Empleados();

            ManagerRepuestos.addEmpleado(adapter.list[e.Position]);
            
            //var l = listView.Adapter.GetItem(e.Position).JavaCast<Empleados>();
            

            this.RunOnUiThread(() => Toast.MakeText(this, adapter.list[e.Position].FullName, ToastLength.Short).Show());

            var activityRepuestosEPIS = new Intent(this, typeof(ListEPISRepuestos));
          
            StartActivity(activityRepuestosEPIS);
            
        }

        public bool OnQueryTextChange(string newText)
        {
            throw new NotImplementedException();
        }

        public bool OnQueryTextSubmit(string query)
        {
            throw new NotImplementedException();
        }
    }
}

