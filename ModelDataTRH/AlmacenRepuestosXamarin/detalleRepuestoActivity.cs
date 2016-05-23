using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Widget.AdapterView;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using AlmacenRepuestosXamarin.Model;
namespace AlmacenRepuestosXamarin
{
    [Activity(Label = "detalleRepuestoActivity")]
    public class detalleRepuestoActivity : AppCompatActivity
    {


        enum DestinosEnum
        {
            T_Mecánico,
            T_Eléctrico, 
            Máquina, 
            Sevilla, 
            Liege, 
            Servicios_Generales, 
            Otros

        }

        private DestinosEnum destinos;
        private Spinner spinnerDestino;
        private Spinner spinnerMaquina;
        private int id;
        private Repuesto repuesto;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.detalleRepuesto);
            // Create your application here
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Almacen Repuestos";



            int.TryParse(Intent.GetStringExtra("idRepuesto"), out id);

            repuesto = ManagerRepuestos.getRepuestoById(id);

            this.RunOnUiThread(() => Toast.MakeText(this, id.ToString(), ToastLength.Short).Show());

            spinnerDestino = (Spinner)FindViewById(Resource.Id.spinnerDestino);

            spinnerDestino.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerDestino_ItemSelected);

            spinnerMaquina = (Spinner)FindViewById(Resource.Id.spinnerMaquina);

            spinnerMaquina.Visibility = ViewStates.Invisible;


            var s = (DestinosEnum[])Enum.GetValues(typeof(DestinosEnum));

            ArrayAdapter<DestinosEnum> adapterDestinos = new ArrayAdapter<DestinosEnum>(this, Android.Resource.Layout.SimpleSpinnerItem,s);
            // Specify the layout to use when the list of choices appears
            adapterDestinos.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            spinnerDestino.Adapter=adapterDestinos;

            ArrayAdapter adapterMaquinas = ArrayAdapter.CreateFromResource(this, Resource.Array.Maquinas, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapterDestinos.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            spinnerMaquina.Adapter = adapterMaquinas;


            EditText edittext = FindViewById<EditText>(Resource.Id.textCantidad);
            edittext.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Up)
                {
                    int cantidad;
                    int.TryParse(edittext.Text, out cantidad);
                    repuesto.quantity = cantidad;
                    Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                    e.Handled = true;
                }
            };

            Button btoAceptar = FindViewById<Button>(Resource.Id.btoAceptar);
            btoAceptar.Click += (object sender, EventArgs e) =>
            {
                Finish();


            };

        }

        #region "Implementacion Interfaz ItemSelectedListener "

        private void spinnerDestino_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;


            this.RunOnUiThread(() => Toast.MakeText(this, spinner.SelectedItem.ToString(), ToastLength.Short).Show());
            repuesto.destino = spinner.SelectedItem.ToString();
            if (spinner.SelectedItem.ToString() == DestinosEnum.Máquina.ToString())
            {

               
                this.spinnerMaquina.Visibility = ViewStates.Visible;

            }
           
        }

        private void spinnerMaquina_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {

            Spinner spinner = (Spinner)sender;
            repuesto.maquina=spinner.SelectedItem.ToString();

        }
       

     

        #endregion

    }
}