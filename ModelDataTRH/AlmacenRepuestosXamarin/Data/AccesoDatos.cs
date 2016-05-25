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
namespace AlmacenRepuestosXamarin.Data
{
    public  class AccesoDatos
    {

        private const string webBase = @"http://intranet.trh-be.com/WSTRH/";
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
            catch (Exception ex )
            {
                return new List<Empleados>();
                throw;
            }

            return null;

        }

    }
}