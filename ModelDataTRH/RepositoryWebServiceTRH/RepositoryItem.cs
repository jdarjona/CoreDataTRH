using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;
using RepositoryWebServiceTRH.ItemContext;

namespace RepositoryWebServiceTRH
{
    class RepositoryItem : IRepository<ItemContext.NuevaListaProductos, String>
    {


        public RepositoryItem()
        {
            Context.CreateContext(new HostWebService(HostWebService.tipoIp.local, HostWebService.empresaWS.TRHSevilla, HostWebService.tipoWebService.Page, "NuevaListaProductos"));
        }
        public void Add(NuevaListaProductos entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<NuevaListaProductos> entitties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NuevaListaProductos> Find(Expression<Func<NuevaListaProductos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public NuevaListaProductos Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NuevaListaProductos> GetAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<NuevaListaProductos> entities)
        {
            throw new NotImplementedException();
        }

        public void Reove(NuevaListaProductos entity)
        {
            throw new NotImplementedException();
        }
    }
}
