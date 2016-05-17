﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RepositoryWebServiceTRH.EmpleadoContext;
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;
using RepositoryWebServiceTRH.AlmacenRepuestosContext;
using RepositoryWebServiceTRH.ItemContext;


namespace RepositoryWebServiceTRH
{
    class Context
    {
        public static Empleados_PortClient contextEmpleado { get; private set; }
        public static EntregaAlmacen_PortClient contextEntregaAlmacenEpis { get; private set; }
        public static AlmacenRepuestos_PortClient contextAlmacenesRepuestos { get; private set; }
        public static NuevaListaProductos_PortClient contextItem { get; private set; }

        public static string usuario=@"TRHSEVILLA0\administrador";

        public static string pass="Paulagallardo2014";

        #region INICIALIZACION DE  WS
        public  static void CreateContext(HostWebService hostWS)
        {
            BasicHttpBinding navisionWSBinding = new BasicHttpBinding();
            navisionWSBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            navisionWSBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            navisionWSBinding.MaxReceivedMessageSize = 2000971520;
            initEmpleadosPortCliente(navisionWSBinding,hostWS.urlHost);
        }
        #endregion

        #region INICIALIZACION DE PORT_CLIENTS
        private static void initEmpleadosPortCliente(BasicHttpBinding navisionWSBinding, string url)
        {
            contextEmpleado = new Empleados_PortClient(navisionWSBinding, new EndpointAddress(string.Format(url,"Empleados")));
            contextEmpleado.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
            contextEmpleado.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(usuario,pass);
        }

        private static void initEntregaAlmacenEpisPortCliente(BasicHttpBinding navisionWSBinding, string url)
        {
            contextEntregaAlmacenEpis = new EntregaAlmacen_PortClient(navisionWSBinding, new EndpointAddress(string.Format(url, "EntragaAlmacen")));
            contextEntregaAlmacenEpis.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
            contextEntregaAlmacenEpis.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(usuario, pass);
        }

        private static void initAlmacenesClientesPortCliente(BasicHttpBinding navisionWSBinding, string url)
        {
            contextAlmacenesRepuestos = new AlmacenRepuestos_PortClient(navisionWSBinding, new EndpointAddress(string.Format(url, "AlmacenRepuestos")));
            contextAlmacenesRepuestos.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
            contextAlmacenesRepuestos.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(usuario, pass);
        }
        private static void initItemPortCliente(BasicHttpBinding navisionWSBinding, string url)
        {
            contextItem = new NuevaListaProductos_PortClient(navisionWSBinding, new EndpointAddress(string.Format(url, "NuevaListaProductos")));
            contextItem.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
            contextItem.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(usuario, pass);
        }


        #endregion
    }

        #region OBTENCION DE URL
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
            urlHost = string.Format(@"http://{0}:7047/DynamicsNAV/WS/{1}/{2}/{3}",this.IpHost,this.empresaServicio,this.tipoWS,@"{0}");
    }


    }
    #endregion

}
