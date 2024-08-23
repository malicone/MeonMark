using MeonMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.Repositories.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity, new()
    {
        event EventHandler<TEntity>? OnEntityAdded;
        event EventHandler<TEntity>? OnEntityUpdated;
        event EventHandler<TEntity>? OnEntityDeleted;
        Task<TEntity> GetAsync( int id );
        Task<List<TEntity>> GetAllAsync();
        Task<int> AddAsync( TEntity entity );
        Task UpdateAsync( TEntity entity );
        Task<int> AddOrUpdateAsync( TEntity entity );
        Task DeleteAsync( int id );
    }
}
