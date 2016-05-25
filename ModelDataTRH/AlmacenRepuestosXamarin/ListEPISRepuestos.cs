using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlmacenRepuestosXamarin.Adapter;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ZXing.Mobile;
using System.Threading.Tasks;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using AlmacenRepuestosXamarin.Model;
using RepositoryWebServiceTRH.EmpleadoContext;
namespace AlmacenRepuestosXamarin
{
    


    [Activity(Label = "ListEPISRepuestos")]
    public class ListEPISRepuestos : AppCompatActivity
    {

        List<Repuesto> listRepuestosEpis;
        Empleados empleado;
        int cantidad;
        AdapterRepuestos adapterRepuestos;
        //AdapterEmpleados adapterEmpleados;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListEPISRepuestos);
            // Create your application here

            empleado = ManagerRepuestos.getEmpleado();


            MobileBarcodeScanner.Initialize(Application);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = empleado.FullName;



            
            listRepuestosEpis =  ManagerRepuestos.getRepuestos() ;
            ListView listViewEmpleados = (ListView)FindViewById(Resource.Id.listProductos);
            adapterRepuestos = new AdapterRepuestos(this, listRepuestosEpis);//new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1, listRepuestosEpis);

            //listViewEmpleados.ItemClick += OnListItemClick;
            listViewEmpleados.Adapter = adapterRepuestos;


        }

        protected override void OnResume()
        {
            base.OnResume();

            this.adapterRepuestos.NotifyDataSetChanged();

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Top ActionBar pressed: " + item.TitleFormatted, ToastLength.Short).Show();

            switch (item.ItemId)
            {
                case Resource.Id.menu_scan:

                     var code=launchScaner();
                     

                    return true;
                    break;

                default:

                    return base.OnOptionsItemSelected(item);
                    break;
            }

        }


        private async Task launchScaner()
        {


            var scanner = new MobileBarcodeScanner();
            Button flashButton;
            View zxingOverlay;

            scanner.UseCustomOverlay = true;

            //Inflate our custom overlay from a resource layout
            zxingOverlay = LayoutInflater.FromContext(this).Inflate(Resource.Layout.OverlayReadBarCode, null);

            //Find the button from our resource layout and wire up the click event
            flashButton = zxingOverlay.FindViewById<Button>(Resource.Id.buttonZxingFlash);
            flashButton.Click += (sender, e) => scanner.ToggleTorch();

            //Set our custom overlay
            scanner.CustomOverlay = zxingOverlay;

            //Start scanning!
            var result = await scanner.Scan();


            //HandleScanResult(result);

            string msg = "";

            if (result != null && !string.IsNullOrEmpty(result.Text)) { 
                msg = "Found Barcode: " + result.Text;
                Repuesto rep = new Repuesto { idRepuesto = 1, description = result.Text, quantity = 0 };
                int id=ManagerRepuestos.addRepuesto(rep);

                this.adapterRepuestos.NotifyDataSetChanged();
                var activityDetalleRepuestoActivity = new Intent(this, typeof(detalleRepuestoActivity));
                activityDetalleRepuestoActivity.PutExtra("idRepuesto", id.ToString());
                StartActivity(activityDetalleRepuestoActivity);
            }
            else
                msg = "Scanning Canceled!";

            this.RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Short).Show());
        }
    }
}