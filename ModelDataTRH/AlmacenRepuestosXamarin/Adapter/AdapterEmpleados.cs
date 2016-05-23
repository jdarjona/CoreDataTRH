using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RepositoryWebServiceTRH.EmpleadoContext;
using AlmacenRepuestosXamarin.Model;

namespace AlmacenRepuestosXamarin.Adapter
{
    public class AdapterEmpleados : BaseAdapter<Empleados>
    {

        Activity context;
        List<Empleados> list;

        public AdapterEmpleados(Activity _context, List<Empleados> _list)
            : base()
        {
            this.context = _context;
            this.list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Empleados this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.spinnerLayout, parent, false);

            Empleados item = this[position];

            view.FindViewById<TextView>(Resource.Id.textoSpinner).Text = item.FullName.ToString();
           

            return view;
        }
    }
}
