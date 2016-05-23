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
            throw new NotImplementedException();
        }

        public IEnumerable<EntregaAlmacen> GetAll()
        {
            throw new NotImplementedException();
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
