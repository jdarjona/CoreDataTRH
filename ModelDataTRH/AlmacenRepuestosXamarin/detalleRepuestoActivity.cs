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
using AlmacenRepuestosXamarin.Adapter;
namespace AlmacenRepuestosXamarin
{
    [Activity(Label = "detalleRepuestoActivity")]
    public class detalleRepuestoActivity : AppCompatActivity
    {


        enum DestinosEnum
        {
            Taller_Mec�nico,
            Taller_El�ctrico, 
            M�quina, 
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

            spinnerMaquina.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerMaquina_ItemSelected);

            spinnerMaquina.Visibility = ViewStates.Invisible;


            var s = (DestinosEnum[])Enum.GetValues(typeof(DestinosEnum));
            
            AdapterSpinner<DestinosEnum> adapterDestinos = new AdapterSpinner<DestinosEnum>(this, Android.Resource.Layout.SimpleSpinnerItem,s);
            // Specify the layout to use when the list of choices appears
            adapterDestinos.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            spinnerDestino.Adapter=adapterDestinos;

            string[] Maquinas = new String[] { "M1", "M2", "M3", "M4", "R1", "R2", "R3", "R4", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8" };
            AdapterSpinner<String> adapterMaquinas = new AdapterSpinner<String>(this, Android.Resource.Layout.SimpleSpinnerItem, Maquinas); 
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

            this.spinnerMaquina.Visibility = ViewStates.Invisible;
            if (spinner.SelectedItem.ToString() == DestinosEnum.M�quina.ToString())
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