using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ModernHttpClient;
using Newtonsoft.Json;
using RepositoryWebServiceTRH.EmpleadoContext;
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;
namespace AlmacenRepuestosXamarin.Data
{
    public  class AccesoDatos
    {
       private const string webBase = @"http://intranet.trh-be.com/WSTRH/";
      //  private const string webBase = @"http://192.168.1.2/WSTRH/";
        private  HttpClient client = new HttpClient(new NativeMessageHandler());


        public AccesoDatos()
        {
             client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(webBase)
            };


            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public  async Task<List<Empleados>> getEmpleados()
        {
            try
            {
                // Uri uri = new Uri(string.Format("{0}/{1}", webBase, @"api/Empleado"));
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(@"api/Empleado");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<Empleados>>(content);
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Se ha producido una excipcion no controlada", ex.InnerException);
            }
            
            return null;
        }

        public async Task<EntregaAlmacen> addRepuesto(string codEmpleado,string codRepuesto) {

            try
            {
                
                //var json = JsonConvert.SerializeObject(item);
                var contentPost = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                string url = string.Format(@"api/EntregaAlmacen?codRepusto={0}&codEmpleado={1}", codRepuesto, codEmpleado);
                var response = await client.PostAsync(url, contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<EntregaAlmacen>(content);
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Se ha producido una excepcion no controlada", ex.InnerException);
            }

            return null;

        }

        public async Task<bool> deleteRepuesto(string key) {

            string url = string.Format(@"api/EntregaAlmacen?key={0}", key);
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Empleados>>(content);
                return true;
            }
            return false;
        }

        public async Task<bool> registerEntrega(string codEmpleado) {

            try
            {
                var contentPost = new StringContent(null, Encoding.UTF8, "application/json");
                string url = string.Format(@"api/EntregaAlmacen?codEmpleado={0}",  codEmpleado);
                var response = await client.PutAsync(url, contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<bool>(content);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Se ha producido una excipcion no controlada", ex.InnerException);
            }
            return false;

        }


    }
}