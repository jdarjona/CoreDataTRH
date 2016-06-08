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

namespace AlmacenRepuestosXamarin.Adapter
{
    public class AdapterSpinner<T> : ArrayAdapter<T> 
    {

        private Activity context;
        public T[] arrayObjets;
        public AdapterSpinner(Activity _context, int textViewResourceId,T[] objects):base(_context,textViewResourceId,objects)
        {
            this.context = _context;
            this.arrayObjets = objects;
        }

    
        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            return getCustomView(position, convertView, parent);
        }

     
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return getCustomView(position, convertView, parent);
        }

        public View getCustomView(int position, View convertView, ViewGroup parent)
        {
            
            View row = convertView;
            if (row == null)
                row = context.LayoutInflater.Inflate(Resource.Layout.spinnerLayout, parent, false);

            TextView label = (TextView)row.FindViewById(Resource.Id.textoSpinner);
            label.Text = arrayObjets[position].ToString().Replace("_blank_", String.Empty).Replace("_"," ");


            return row;
        }
    }
}