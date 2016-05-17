using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RepositoryWebServiceTRH.EmpleadoContext;

namespace RepositoryWebServiceTRH
{
    class Context
    {

       
        public static EmpleadoContext.Empleados_PortClient contextEmpleado { get; private set; }

        
        public  static void CreateContext(HostWebService hostWS) {


            BasicHttpBinding navisionWSBinding = new BasicHttpBinding();
            navisionWSBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            navisionWSBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            navisionWSBinding.MaxReceivedMessageSize = 2000971520;


            initEmpleadosPortCliente(navisionWSBinding,hostWS.urlHost);

        }

        private static void initEmpleadosPortCliente(BasicHttpBinding navisionWSBinding, string url)
        {

            contextEmpleado = new Empleados_PortClient(navisionWSBinding, new EndpointAddress(string.Format(url,"Empleados")));
            contextEmpleado.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
            contextEmpleado.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential("TRHSEVILLA0\administrador", "Paulagallardo2014");

        }



    }

    class HostWebService {

        public enum tipoWebService
        {
            Page
           , CodeUnit
        }
        public enum tipoIp {
            publica,
            local
        }
        public enum empresaWS {
              TRHSevilla,
              TRHLieja
        }

        public tipoWebService tipoServicioWeb { get; set; }

        public string urlHost { get; }
        private string IpHost;
        private string empresaServicio;
        private string tipoWS = string.Empty;
         

        public HostWebService(tipoIp tipoIPHost, empresaWS empresaServicio, tipoWebService tipoWS, string entidadWS) {

            switch (tipoWS)
            {
                case tipoWebService.Page:
                    this.tipoWS = "Page";
                    break;
                case tipoWebService.CodeUnit:
                    this.tipoWS = "Codeunit";
                    break;
               
            }

            switch (empresaServicio)
            {
                case empresaWS.TRHSevilla:
                    this.empresaServicio = "T.R.H.";
                    break;
                case empresaWS.TRHLieja:
                    this.empresaServicio = "TRH Liege";
                    break;
                default:
                    break;
            }

            switch (tipoIPHost)
            {
                case tipoIp.publica:
                    this.IpHost = empresaServicio == empresaWS.TRHSevilla ? "intranet.trh-es.com" : "intranet.trh-be.com";
                    break;
                case tipoIp.local:
                    this.IpHost = "192.168.1.2";
                    break;
                default:
                    break;
            }
            urlHost = string.Format(@"http://{0}/DynamicsNAV/WS/{1}/{2}/{3}",this.IpHost,this.empresaServicio,this.tipoWS,@"{0}");
    }


    }

     
}
