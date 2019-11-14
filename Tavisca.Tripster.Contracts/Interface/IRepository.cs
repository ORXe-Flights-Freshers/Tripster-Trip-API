using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> Update(Guid id, TEntity entity);
    }

}
