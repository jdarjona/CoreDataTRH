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
        [Test]
        public void Get_ById_ReturnEmpleado()
        {

            RepositoryWebServiceTRH.RepositoryEmpleado repoEmpleado = new RepositoryEmpleado() ;
            string id = "E0001";
            var empleado=repoEmpleado.Get(id);

            Assert.AreNotEqual(null, empleado, string.Format(@"No hemos encontrado el empleado {0}", id));
            // TODO: Add your test code here
          
        }

        [Test]
        public void Get_ParametroNull_ReturnException() {

            RepositoryWebServiceTRH.RepositoryEmpleado repoEmpleado = new RepositoryEmpleado();
            string id = null;
            //var empleado = repoEmpleado.Get(id);

            Assert.Throws<ArgumentNullException>(() => repoEmpleado.Get(id));
           // Assert.AreNotEqual(null, empleado, string.Format(@"Hemos encontrado el empleado {0}", id));

        }

        [Test]
        public void Find_Querry_ReturnAny()
        {

            RepositoryWebServiceTRH.RepositoryEmpleado repoEmpleado = new RepositoryEmpleado();
            string id = "E0001";
            //var empleado = repoEmpleado.Find(System.Linq.Expressions.Expression<Func<RepositoryWebServiceTRH.EmpleadoContext.Empleados, true>> );

            Assert.Throws<ArgumentNullException>(() => repoEmpleado.Get(id));
            // Assert.AreNotEqual(null, empleado, string.Format(@"Hemos encontrado el empleado {0}", id));

        }
    }
}
