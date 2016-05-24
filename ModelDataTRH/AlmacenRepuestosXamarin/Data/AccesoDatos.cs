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
using Newtonsoft.Json;
using RepositoryWebServiceTRH.EmpleadoContext;
namespace AlmacenRepuestosXamarin.Data
{
    public static class AccesoDatos
    {

        private const string webBase = @"http://192.168.1.2/WSTRH";
        private static HttpClient client= new HttpClient();

        public static async Task<List<Empleados>> getEmpleados()
        {
            Uri uri = new Uri(string.Format("{0}/{1}", webBase, @"api/Empleado"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
               
                var result=JsonConvert.DeserializeObject<List<Empleados>>(content);
                return result;
            }
            return null;
        }

    }
}