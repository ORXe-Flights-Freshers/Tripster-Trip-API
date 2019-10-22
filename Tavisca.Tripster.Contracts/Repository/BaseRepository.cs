using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
        public virtual void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
