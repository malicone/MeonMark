using MeonMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.Repositories.Interface
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public event EventHandler<TEntity>? OnEntityAdded;
        public event EventHandler<TEntity>? OnEntityUpdated;
        public event EventHandler<TEntity>? OnEntityDeleted;

        // TODO: override finalizer only if 'Dispose(bool freeManagedResources)' has code to free unmanaged resources
        ~BaseRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool freeManagedResources)' method
            Dispose( freeManagedResources: false );
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool freeManagedResources)' method
            Dispose( freeManagedResources: true );
            GC.SuppressFinalize( this );
        }

        public abstract Task<int> AddAsync( TEntity entity );
        public abstract Task<int> AddOrUpdateAsync( TEntity entity );
        public abstract Task DeleteAsync( int id );
        public abstract Task<List<TEntity>> GetAllAsync();
        public abstract Task<TEntity> GetAsync( int id );
        public abstract Task UpdateAsync( TEntity entity );

        protected virtual void Dispose( bool freeManagedResources )
        {
            if ( !_alreadyDisposed )
            {
                if ( freeManagedResources )
                {
                    // TODO: dispose managed state (managed objects)
                    FreeManagedResources();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                FreeUnmanagedResources();
                _alreadyDisposed = true;
            }
        }

        protected abstract void FreeManagedResources();
        protected abstract void FreeUnmanagedResources();

        private bool _alreadyDisposed;
    }
}
