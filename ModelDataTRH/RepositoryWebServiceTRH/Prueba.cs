using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebServiceTRH
{
    class Prueba
    {
        string ip = string.Empty;
        string empresa = string.Empty;
        string tipoWS = string.Empty;
        string nombreWS = string.Empty;
        string urlHost = string.Empty;

        public string getUrl(string ip, string empresa, string tipoWS,string nombreWS) {
            try
            {
                return this.urlHost = string.Format(@"http://{0}/DynamicsNAV/WS/{1}/{2}/{3}", ip, empresa, this.tipoWS, nombreWS);
            }
            catch (Exception e)
            {
                return e.ToString();
            }  
        }



        public void openservice(string url,Object ws) {

           // Letters ws = new Letters();

            // Use default credentials for authenticating 
            // against Microsoft Dynamics NAV.
            ws.UseDefaultCredentials = true;
            ws.Url = url;

            // Declare variables to work with.
            string inputstring, outputstring;
            inputstring = "microsoft dynamics nav web services!";

            // Call the Microsoft Dynamics NAV codeunit Web service.
            outputstring = ws.Capitalize(inputstring);

            // Write output to the screen.
            Console.WriteLine("Result: {0}", outputstring);

            // Keep the console window open until you press ENTER.
            Console.ReadLine();
        }
        
        
            private ServiceDescriptionImporter BuildServiceDescriptionImporter(string webserviceUri)
        {
            ServiceDescriptionImporter descriptionImporter = null;

            **WebClient client = new WebClient { Proxy = new WebProxy(string host, int port) }; **

           Stream stream = client.OpenRead(webserviceUri);

            XmlTextReader xmlreader = new XmlTextReader(stream);

            // parse wsdl
            ServiceDescription serviceDescription = ServiceDescription.Read(xmlreader);

            // build an importer, that assumes the SOAP protocol, client binding, and generates properties
            descriptionImporter = new ServiceDescriptionImporter();
            descriptionImporter.ProtocolName = "Soap12";
            descriptionImporter.AddServiceDescription(serviceDescription, null, null);
            descriptionImporter.Style = ServiceDescriptionImportStyle.Client;
            descriptionImporter.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;

            return descriptionImporter;
        }

    }
}
