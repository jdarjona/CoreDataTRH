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

namespace AlmacenRepuestosXamarin.Model
{
    public class Repuesto
    {
        public int idRepuesto {get;set;}
        public string description { get; set; }
        public int quantity { get; set; }
        public string destino { get; set; }
        public string maquina { get; set; }



    }

    public static class ManagerRepuestos {

        private static List<Repuesto> repuestos= new List<Repuesto>();
        private static int count;
        public static int  addRepuesto(Repuesto repuesto) {

            count += 1;

            repuesto.idRepuesto = count;

            repuesto.description = repuesto.description + "_" + count.ToString();

            repuestos.Add(repuesto);

            return repuesto.idRepuesto;
        }

        public static List<Repuesto> getRepuestos() {
            return repuestos;
        }

        public static Repuesto getRepuestoById(int id) {

            return  repuestos.Where(q => q.idRepuesto.Equals(id)).First();
        }





    }
}