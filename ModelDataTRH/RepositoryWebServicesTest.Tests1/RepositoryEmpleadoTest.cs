using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryWebServiceTRH;
namespace RepositoryWebServicesTest.Tests1
{
    [TestFixture]
    public class RepositoryEmpleadoTest
    {
        private HostWebService hostWs;

        [SetUp]
        public void initEmpeladoContext() {

            hostWs = new HostWebService(HostWebService.tipoIp.local, HostWebService.empresaWS.TRHSevilla, HostWebService.tipoWebService.Page, "Empleados", @"TRHSEVILLA0\administrador", "Paulagallardo2014");


        }
        [Test]
        public void Get_ById_ReturnEmpleado()
        {

            
            RepositoryWebServiceTRH.RepositoryEmpleado repoEmpleado = new RepositoryEmpleado(hostWs) ;
            string id = "E0001";
            var empleado=repoEmpleado.Get(id);

            Assert.AreNotEqual(null, empleado, string.Format(@"No hemos encontrado el empleado {0}", id));
            // TODO: Add your test code here
          
        }

        [Test]
        public void Get_ParametroNull_ReturnException() {

            RepositoryWebServiceTRH.RepositoryEmpleado repoEmpleado = new RepositoryEmpleado(hostWs);
            string id = null;
            //var empleado = repoEmpleado.Get(id);

            Assert.Throws<ArgumentNullException>(() => repoEmpleado.Get(id));
           // Assert.AreNotEqual(null, empleado, string.Format(@"Hemos encontrado el empleado {0}", id));

        }

        //[Test]
        //public void Find_Querry_ReturnAny()
        //{

        //    RepositoryWebServiceTRH.RepositoryEmpleado repoEmpleado = new RepositoryEmpleado(hostWs);
           
        //    System.Linq.Expressions.Expression<Func<RepositoryWebServiceTRH.EmpleadoContext.Empleados, bool>> expr =q=>q.Name.StartsWith("Manuel");
        //    var empleado = repoEmpleado.Find(expr);

            
        //    Assert.AreNotEqual(null, empleado.ToList());

        //}
    }
}
