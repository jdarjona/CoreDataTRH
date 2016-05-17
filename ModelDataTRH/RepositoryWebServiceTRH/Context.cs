using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebServiceTRH
{
    class Context
    {

       
        public EmpleadoContext contextEmpleado { get;set }
        
        public  static void CreateContext(HostWebService hostWS) {



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
            urlHost = string.Format(@"http://{0}/DynamicsNAV/WS/{1}/{2}/{3}",this.IpHost,this.empresaServicio,this.tipoWS,entidadWS);
    }


    }

     
}
