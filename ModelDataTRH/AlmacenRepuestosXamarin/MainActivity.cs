using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using AlmacenRepuestosXamarin.Adapter;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using System.Collections.Generic;
using Tesseract;
using Tesseract.Droid;
using RepositoryWebServiceTRH.EmpleadoContext;
using RepositoryWebServiceTRH;
namespace AlmacenRepuestosXamarin
{
    [Activity(Label = "AlmacenRepuestosXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        
        
        List<string> items;
        List<Empleados> empleados=new List<Empleados>();
        Data.AccesoDatos restService = new Data.AccesoDatos();
        //ArrayAdapter adapterEmpleados;
        Adapter.AdapterEmpleados adaptardoEmpleados;

        private Task<bool> api;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Almacen Repuestos";
           
            items = new List<string>() { "Menganito", "Sutanito", "Fulanito", "Pepito", "Jaimito", "Luisito" };

            
            
           

            ITesseractApi api = new TesseractApi(this, AssetsDeployment.OncePerInitialization);

            empleados=await getEmpleados();
            ListView listViewEmpleados = (ListView)FindViewById(Resource.Id.listEmpleados);
            adaptardoEmpleados = new Adapter.AdapterEmpleados(this, empleados);
            listViewEmpleados.ItemClick += OnListItemClick;
            listViewEmpleados.Adapter = adaptardoEmpleados;
        }

        private async Task<List<Empleados>> getEmpleados()
        {
           
            var query=await restService.getEmpleados();
            return query;









        }

        //protected override void OnListItemClick(ListView l, View v, int position, long id)
        //{
        //    var t = items[position];
        //    Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
        //    Console.WriteLine("Clicked on " + t);
        //}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override  bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Top ActionBar pressed: " + item.TitleFormatted, ToastLength.Short).Show();

            switch (item.ItemId)
            {
                case Resource.Id.menu_scan:

                    // var code=launchScaner();
                    
                    return true;
                    break;

                default:

                    return base.OnOptionsItemSelected(item);
                    break;
            }

        }


        //private async Task launchScaner()
        //{


          

        //    //this.RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Short).Show());
        //}



        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
            var item = items[e.Position];

            this.RunOnUiThread(() => Toast.MakeText(this, item, ToastLength.Short).Show());

            var activityRepuestosEPIS = new Intent(this, typeof(ListEPISRepuestos));
            activityRepuestosEPIS.PutExtra("Item", item);
            

            StartActivity(activityRepuestosEPIS);
            
        }



        //void AddTab(string tabText, int iconResourceId, Fragment view)
        //{
        //    var tab = this.ActionBar.NewTab();
        //    tab.SetText(tabText);
        //    tab.SetIcon(Resource.Drawable.ic_tab_white);

        //    // must set event handler before adding tab
        //    tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
        //    {
        //        //var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
        //        //if (fragment != null)
        //        //    e.FragmentTransaction.Remove(fragment);
        //        e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
        //    };
        //    tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) {
        //        e.FragmentTransaction.Remove(view);
        //    };

        //    this.ActionBar.AddTab(tab);
        //}


    }
}

