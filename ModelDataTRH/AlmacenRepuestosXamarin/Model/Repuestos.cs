using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmacenRepuestosXamarin.Data;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RepositoryWebServiceTRH.EmpleadoContext;
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;

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

        private static List<EntregaAlmacen> repuestos= new List<EntregaAlmacen>();
        private static Empleados empleado;

        private static int count;
        private static AccesoDatos datos = new AccesoDatos();
        public static async Task<EntregaAlmacen> addRepuesto(string codEmpleado, string codRepuesto) {


            EntregaAlmacen repuesto=await datos.addRepuesto(codEmpleado, codRepuesto);
            repuestos.Add(repuesto);

            return repuesto;
        }

        public static List<EntregaAlmacen> getRepuestos() {
            return repuestos;
        }

        public static EntregaAlmacen getRepuestoByKey(string Key) {

            return  repuestos.Where(q => q.Key.Equals(Key)).First();
        }


        public static void addEmpleado(Empleados _empleado) {

            empleado = _empleado;
        }

        public static Empleados getEmpleado() {
            return empleado;
        }

        public static void limpiarRepuestos()
        {
            repuestos.Clear();
        }
    }
}