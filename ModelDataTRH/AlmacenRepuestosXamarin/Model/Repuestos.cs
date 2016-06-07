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

        public static async Task<EntregaAlmacen> updateRepuesto(EntregaAlmacen repuesto)
        {

            return await datos.updateRepuesto(repuesto);


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
            foreach(EntregaAlmacen rep in repuestos)
            {
                eliminarRepuesto(rep.Key);
            }
        }

        public static bool existeRepuestoEnLista(string emple, string n)
        {
            bool aux = false;
            foreach (EntregaAlmacen repuesto in repuestos)
            {
                if (repuesto.Cod_Producto.Equals(n) && repuesto.Cod_Empleado.Equals(emple))
                {
                    aux = true;
                }
            }

            return aux;
        }

        public static async Task<bool> eliminarRepuesto(string key)
        {
            await datos.deleteRepuesto(key);
            var item = repuestos.Single(r => r.Key == key);
            
            repuestos.Remove(item);

            return true;
           // ListEPISRepuestos.actualizarLista();
        }
        
        public static async void registrarLista(string emple)
        {
           
            var ok=await datos.registerEntrega(emple);
            if (ok) {
                repuestos.Clear();
            }
           
        }

        public static async Task<string> getAlbaran(string url) {


            return await datos.downloadFile(url);
        }
    }
}