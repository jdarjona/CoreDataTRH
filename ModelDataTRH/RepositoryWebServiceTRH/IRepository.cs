using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RepositoryWebServiceTRH
{
    public interface IRepository<TEntity,Tid> where TEntity:class
    {

        TEntity Get(Tid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entitties);

        void Reove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        

    }
}
