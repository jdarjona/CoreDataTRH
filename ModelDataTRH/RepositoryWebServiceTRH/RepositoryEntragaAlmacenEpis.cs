using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;

namespace RepositoryWebServiceTRH
{
    class RepositoryEntragaAlmacenEpis : RespositoryBase, IRepository<EntregaAlmacenEpisContext.EntregaAlmacen, String>
    {
        public RepositoryEntragaAlmacenEpis(HostWebService hostWs) : base(hostWs)
        {

        }

        public void Add(EntregaAlmacen entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<EntregaAlmacen> entitties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntregaAlmacen> Find(Expression<Func<EntregaAlmacen, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public EntregaAlmacen Get(string id)
        {
            int numLienea = 1000;
            DateTime fecha = new DateTime();
            try
            {

                return Context.contextEntregaAlmacenEpis.Read("CodEmpleado","CodProducto",fecha,numLienea);
              //  return Context.contextEntregaAlmacenEpis.ReadByRecId("CodEmpleado");
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("id", "El parametro 'id' no puede vernir vacio");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo Get] [Item] ", ex.Message), ex.InnerException);
            }
        }

        public IEnumerable<EntregaAlmacen> GetAll()
        {
            try
            {
                return Context.contextEntregaAlmacenEpis.ReadMultiple(null, null, 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado: ", ex.InnerException);
            }
        }

        public void RemoveRange(IEnumerable<EntregaAlmacen> entities)
        {
            throw new NotImplementedException();
        }

        public void Reove(EntregaAlmacen entity)
        {
            throw new NotImplementedException();
        }
    }
}
