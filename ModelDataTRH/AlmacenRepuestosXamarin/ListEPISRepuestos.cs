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
using Com.Wdullaer.Swipeactionadapter;

namespace AlmacenRepuestosXamarin
{
    [Activity(Label = "ListEPISRepuestos",  ScreenOrientation = ScreenOrientation.Portrait)]
    public class ListEPISRepuestos : AppCompatActivity, SwipeActionAdapter.ISwipeActionListener
    {

        List<EntregaAlmacen> listRepuestosEpis;
        Empleados empleado;
        AdapterRepuestos adapterRepuestos;
        SwipeActionAdapter adaptarSwipe;
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

            // adapterRepuestos;

            adaptarSwipe = new SwipeActionAdapter(adapterRepuestos);

            adaptarSwipe.SetSwipeActionListener(this)
                   .SetDimBackgrounds(true)
                   .SetListView(this.listViewEmpleados);

            listViewEmpleados.Adapter = adaptarSwipe;
            adaptarSwipe.AddBackground(SwipeDirection.DirectionFarLeft, Resource.Menu.row_bg_left_far);
            adaptarSwipe.AddBackground(SwipeDirection.DirectionNormalLeft, Resource.Menu.row_bg_left);
            adaptarSwipe.AddBackground(SwipeDirection.DirectionFarRight, Resource.Menu.row_bg_right_far);
            adaptarSwipe.AddBackground(SwipeDirection.DirectionNormalRight, Resource.Menu.row_bg_right);

           



            //listViewEmpleados.ItemClick += OnListItemClick;

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

            this.adaptarSwipe.NotifyDataSetChanged();
            //this.adapterRepuestos.NotifyDataSetChanged();

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
                       
                        ManagerRepuestos.registrarLista(empleado.No,adapterRepuestos.list.ToArray<EntregaAlmacen>());
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

                    adaptarSwipe.NotifyDataSetChanged();
                    //this.adapterRepuestos.NotifyDataSetChanged();
                    var activityDetalleRepuestoActivity = new Intent(this, typeof(detalleRepuestoActivity));
                    activityDetalleRepuestoActivity.PutExtra("idEntregaAlmacen", rep.Key);
                    StartActivity(activityDetalleRepuestoActivity);
                }
            }
            else
                msg = "Scanning Canceled!";

            
            this.RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Short).Show());
        }

        public bool HasActions(int p0, SwipeDirection direction)
        {
            if (direction.IsLeft) return true; // Change this to false to disable left swipes
            if (direction.IsRight) return true;
            return false;
        }

        public  void OnSwipe(int[] positionList, SwipeDirection[] directionList)
        {
            for (int i = 0; i < positionList.Length; i++)
            {
                SwipeDirection direction = directionList[i];
                int position = positionList[i];
                String dir = "";

                if (direction == SwipeDirection.DirectionFarLeft)
                {
                    dir = "Far left";
                }
                else if (direction == SwipeDirection.DirectionNormalLeft)
                {
                    dir = "Left";
                }
                else if (direction == SwipeDirection.DirectionFarRight)
                {
                    Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                    alert.SetTitle("�Estas seguro de eliminar el repuesto?");
                    //alert.SetMessage("Si ");
                    alert.SetPositiveButton("S�", (s, e) =>
                    {
                        var item = adapterRepuestos.list[position];

                        eliminarRepuesto(item);

                    });
                    alert.SetNegativeButton("NO", (s, e) =>
                    {

                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
                else if (direction == SwipeDirection.DirectionNormalRight)
                {
                    
                   
                }


                
            }
        }
        public bool ShouldDismiss(int p0, SwipeDirection direction)
        {
            return direction == SwipeDirection.DirectionNormalLeft;
        }

        private async void eliminarRepuesto(EntregaAlmacen item) {

            await ManagerRepuestos.eliminarRepuesto(item.Key);
            this.adaptarSwipe.NotifyDataSetChanged();
            
        }

    }
}