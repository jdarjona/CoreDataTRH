using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Widget.AdapterView;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using AlmacenRepuestosXamarin.Model;
using AlmacenRepuestosXamarin.Adapter;
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;
using Android.Graphics.Drawables;
using Android.Views.InputMethods;
using Android.Content.PM;
using static Android.Views.View;
using System.Text;

namespace AlmacenRepuestosXamarin
{
    [Activity(Label = "detalleRepuestoActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class detalleRepuestoActivity : AppCompatActivity
    {


       

        //private DestinosEnum destinos;
        private Destino destinos;
        private Maquina maquinas;
        AdapterSpinner<Destino> adapterDestinos;
        AdapterSpinner<Maquina> adapterMaquinas;
        EditText edittext;
        Drawable warning;
        private Spinner spinnerDestino;
        private Spinner spinnerMaquina;
        private int id;
        private EntregaAlmacen repuesto;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.detalleRepuesto);
            // Create your application here
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            string key = Intent.GetStringExtra("idEntregaAlmacen");
            repuesto = ManagerRepuestos.getRepuestoByKey(key);

            SupportActionBar.Title = string.Format(@"{0} - {1}",repuesto.Cod_Producto,repuesto.Unit_of_Measure_Code);

          
           

            this.RunOnUiThread(() => Toast.MakeText(this, id.ToString(), ToastLength.Short).Show());

            edittext = FindViewById<EditText>(Resource.Id.textCantidad);
           

                //edittext.SetText(Int32.Parse(repuesto.Cantidad.ToString()));
            edittext.TextChanged += Edittext_TextChanged;
            if (repuesto.Cantidad != 0)
            {
                edittext.Text = repuesto.Cantidad.ToString();
            }
            else
            {
                edittext.Text = string.Empty;
            }

            //spinnerDestino.SetSelection(repuesto.) = 0;
            edittext.FocusChange += (sender, args) =>
            {
                bool isFocused = args.HasFocus;
                if (!isFocused)
                {
                    spinner_OnClick(sender);
                }
            };

            spinnerDestino = (Spinner)FindViewById(Resource.Id.spinnerDestino);

            spinnerDestino.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerDestino_ItemSelected);
            //spinnerDestino.ItemClick += spinner_OnClick;


            spinnerMaquina = (Spinner)FindViewById(Resource.Id.spinnerMaquina);

            spinnerMaquina.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerMaquina_ItemSelected);
            spinnerMaquina.Visibility = ViewStates.Invisible;
            //spinnerMaquina.ItemClick += spinner_OnClick;

         
            var s = (Destino[])Enum.GetValues(typeof(Destino));
            
            adapterDestinos = new AdapterSpinner<Destino>(this, Android.Resource.Layout.SimpleSpinnerItem,s);
            // Specify the layout to use when the list of choices appears
            adapterDestinos.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            spinnerDestino.Adapter=adapterDestinos;

            spinnerDestino.Focusable = true;
            spinnerDestino.FocusableInTouchMode = true;
            spinnerDestino.RequestFocus(FocusSearchDirection.Up);

            //string[] Maquinas = new String[] { "M1", "M2", "M3", "M4", "R1", "R2", "R3", "R4", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8" };

            var arrayMaquinas = (Maquina[])Enum.GetValues(typeof(Maquina));
            adapterMaquinas = new AdapterSpinner<Maquina>(this, Android.Resource.Layout.SimpleSpinnerItem, arrayMaquinas); 
            // Specify the layout to use when the list of choices appears
            adapterDestinos.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            spinnerMaquina.Adapter = adapterMaquinas;
            spinnerMaquina.Focusable = true;
            spinnerMaquina.FocusableInTouchMode = true;
            spinnerMaquina.RequestFocus(FocusSearchDirection.Up);

            TextView textDescription = FindViewById<TextView>(Resource.Id.textDescription);
            textDescription.Text = repuesto.Descripcion_Producto;


            

            Resources.GetDrawable(Android.Resource.Drawable.AlertLightFrame);
             warning = (Drawable)Resources.GetDrawable(Android.Resource.Drawable.AlertLightFrame);

         
            //spinnerDestino.Click += (object sender, EventArgs e) =>
            //{
            //    InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            //    imm.HideSoftInputFromWindow(edittext.WindowToken, 0);
            //};


            Button btoAceptar = FindViewById<Button>(Resource.Id.btoAceptar);

            btoAceptar.Click += OnClik_btoAceptar;

            //    (object sender, EventArgs e) =>
            //{
            //    var _btoAceptar = (Button)sender;
            //    if (repuesto.Cantidad > 0)
            //    {

            //        Finish();
            //    }
            //    else {

            //        _btoAceptar.SetError("Introduza una cantidad antes de aceptar", warning); 
            //    }
            //};


        }

        private async void OnClik_btoAceptar(object sender, EventArgs e) {

            var _btoAceptar = (Button)sender;
            if (validar())
            {

                repuesto=await ManagerRepuestos.updateRepuesto(repuesto);

                Finish();
            }
            else
            {

                _btoAceptar.SetError("Introduza una cantidad antes de aceptar", warning);
            }

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menuDetalle, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {


            switch (item.ItemId)
            {
                case Resource.Id.eliminar:

                    ManagerRepuestos.eliminarRepuesto(repuesto.Key);

                    Toast.MakeText(this, "Se elimin� el repuesto "+repuesto.Cod_Producto+" de la lista", ToastLength.Short).Show();
                    Finish();
                    break;

                default:
                    Finish();

                    break;
            }
            return base.OnOptionsItemSelected(item);

        }

        private void spinner_OnFocus() { }

        private void spinner_OnClick(object sender) {

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(edittext.WindowToken, 0);
        }

       

        private void Edittext_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var editTextCantidad = (EditText)sender;
            int cantidad;
            int.TryParse(editTextCantidad.Text, out cantidad);
            //GetResources().getDrawable(R.drawable.alert_icon);
            if (cantidad > repuesto.Inventory)
            {
                editTextCantidad.SetError(string.Format(@"La cantidad es mayor que las existencias disponibles, Existencias disponible {0}",this.repuesto.Inventory.ToString("N2")), warning);
                cantidad = 0;
                editTextCantidad.Text = string.Empty;

            }

            repuesto.Cantidad = cantidad;
            
        }

        #region "Implementacion Interfaz ItemSelectedListener "

        private void spinnerDestino_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;


            //this.RunOnUiThread(() => Toast.MakeText(this, spinner.SelectedItem.ToString(), ToastLength.Short).Show());
            //repuesto.destino = spinner.SelectedItem.ToString();

            repuesto.Destino = (Destino)adapterDestinos.arrayObjets[e.Position];
            this.spinnerMaquina.Visibility = ViewStates.Invisible;
            if (spinner.SelectedItem.ToString() == Destino.M�quina.ToString())
            {
                this.spinnerMaquina.Visibility = ViewStates.Visible;
            }

          
        }

        private void spinnerMaquina_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {

            Spinner spinner = (Spinner)sender;
            repuesto.Maquina= (Maquina)adapterMaquinas.arrayObjets[e.Position];
            // repuesto.maquina=spinner.SelectedItem.ToString();

        }

        private bool validar() {
            StringBuilder error = new StringBuilder(); ;
            error.Append(string.Empty);
            bool valido = true;
            if (repuesto.Destino == Destino._blank_)
            {
                error.Append("Debe seleccionar un destino");
                error.Append("\n");
                valido = false;

                    
            }
            if (repuesto.Destino== Destino.M�quina && repuesto.Maquina == Maquina._blank_)
            {
                error.Append("Debe seleccionar un maquina");
                error.Append("\n");
                valido = false;


            }
            if (repuesto.Cantidad<=0)
            {
                error.Append("Introduzca cantidad");
                error.Append("\n");
                valido = false;


            }
            if (!valido) {
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("Registro");
                alert.SetIcon(Android.Resource.Drawable.ButtonStar);
                alert.SetMessage(error.ToString());
                alert.SetNeutralButton("Ok", (s, e) => { });

            }

            return valido;
        }
       




        #endregion

    }
}