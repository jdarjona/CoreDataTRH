using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryWebServiceTRH.EmpleadoContext;

namespace RepositoryWebServiceTRH
{
    public class RepositoryEmpleado : IRepository<EmpleadoContext.Empleados, String>
    {

        

        public RepositoryEmpleado() {

            Context.CreateContext(new HostWebService(HostWebService.tipoIp.local, HostWebService.empresaWS.TRHSevilla, HostWebService.tipoWebService.Page, "Empleados"));
        }
        public void Add(Empleados entity)
        {

           
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Empleados> entitties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleados> Find(Expression<Func<Empleados, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Empleados Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return Context.contextEmpleado.Read(id);
            }
            else {

                throw new ArgumentNullException("id", "El parametro id no puede vernir vacio");
            }
            
           
        }

        public IEnumerable<Empleados> GetAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Empleados> entities)
        {
            throw new NotImplementedException();
        }

        public void Reove(Empleados entity)
        {
            throw new NotImplementedException();
        }
    }
}
