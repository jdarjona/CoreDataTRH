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
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;
using Android.Content.PM;

namespace AlmacenRepuestosXamarin
{
    [Activity(Label = "ListEPISRepuestos",  ScreenOrientation = ScreenOrientation.Portrait)]
    public class ListEPISRepuestos : AppCompatActivity
    {

        List<EntregaAlmacen> listRepuestosEpis;
        Empleados empleado;
        static AdapterRepuestos adapterRepuestos;
        ListView listViewEmpleados;

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
            listRepuestosEpis.Clear();
            listViewEmpleados = (ListView)FindViewById(Resource.Id.listProductos);
            adapterRepuestos = new AdapterRepuestos(this, listRepuestosEpis);//new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1, listRepuestosEpis);

            //listViewEmpleados.ItemClick += OnListItemClick;
            listViewEmpleados.Adapter = adapterRepuestos;
            var fab = FindViewById<com.refractored.fab.FloatingActionButton>(Resource.Id.floating);
            fab.AttachToListView(listViewEmpleados);
           // Button btoScan = FindViewById<Button>(Resource.Id.btoScanear);
            fab.Click += (object sender, EventArgs e) =>
            {
                var code = launchScaner();
            };

            listViewEmpleados.ItemClick += (sender,e) =>
            {
                var activityDetalleRepuestoActivity = new Intent(this, typeof(detalleRepuestoActivity));
                activityDetalleRepuestoActivity.PutExtra("idEntregaAlmacen", ManagerRepuestos.getRepuestos()[e.Position].Key);
                StartActivity(activityDetalleRepuestoActivity);
            };
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

      
        public static void actualizarLista()
        {
            adapterRepuestos.NotifyDataSetChanged();
        }

        public override void OnBackPressed()
        {

            if (ManagerRepuestos.getRepuestos().Count != 0)
            {


                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("�Estas seguro de cerrar la lista?");
                alert.SetMessage("Si cierras la lista, estos datos ser�n eliminados.");
                alert.SetPositiveButton("S�", (s, e) =>
                {
                    ManagerRepuestos.limpiarRepuestos();
                    base.OnBackPressed();
                });
                alert.SetNegativeButton("NO", (s, e) =>
                {

                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else {
                
                base.OnBackPressed();
            }


        }
        protected override void OnResume()
        {
            
            base.OnResume();
            adapterRepuestos.NotifyDataSetChanged();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            

            switch (item.ItemId)
            {
                case Resource.Id.registrar:

                    Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                    alert.SetTitle("�Estas seguro de registrar la lista?");
                    alert.SetMessage("Si la registras esos datos no podr�n ser modificados");
                    alert.SetPositiveButton("S�", (s, e) =>
                    {
                        ManagerRepuestos.registrarLista(empleado.No);
                        base.OnBackPressed();
                    });
                    alert.SetNegativeButton("NO", (s, e) =>
                    {

                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();

                    break;

                default:
                    Finish();

                    break;
            }
            return base.OnOptionsItemSelected(item);

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

                if (ManagerRepuestos.existeRepuestoEnLista(empleado.No, result.Text))
                {
                    msg = "Ya fue esaneado ese producto!!";
                }
                else
                {

                    EntregaAlmacen rep = await ManagerRepuestos.addRepuesto(empleado.No, result.Text);


                    adapterRepuestos.NotifyDataSetChanged();
                    var activityDetalleRepuestoActivity = new Intent(this, typeof(detalleRepuestoActivity));
                    activityDetalleRepuestoActivity.PutExtra("idEntregaAlmacen", rep.Key);
                    StartActivity(activityDetalleRepuestoActivity);
                }
            }
            else
                msg = "Scanning Canceled!";

            
            this.RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Short).Show());
        }

    }
}