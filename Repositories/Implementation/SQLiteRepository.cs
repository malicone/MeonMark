using MeonMark.Models;
using MeonMark.Repositories.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.Repositories.Implementation
{
    public class SQLiteRepository<TEntity> : BaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public new event EventHandler<TEntity>? OnEntityAdded;
        public new event EventHandler<TEntity>? OnEntityUpdated;
        public new event EventHandler<TEntity>? OnEntityDeleted;

        public async override Task<int> AddAsync( TEntity entity )
        {
            await CreateConnection();
            if(Connection != null)
            {
                int id = await Connection.InsertAsync( entity );
                OnEntityAdded?.Invoke( this, entity );
                return id;
            }                       
            return -1;
        }

        public async override Task<int> AddOrUpdateAsync( TEntity entity )
        {
            if ( entity.Id == 0 )
            {
                return await AddAsync( entity );
            }
            else
            {
                await UpdateAsync( entity );
                return entity.Id;
            }
        }

        public async override Task<TEntity> GetAsync( int id )
        {
            await CreateConnection();
            if ( Connection != null )
            {
                TEntity entity = await Connection.GetAsync<TEntity>( id );
                return entity;
            }
            return new TEntity();
        }

        public async override Task<List<TEntity>> GetAllAsync()
        {
            await CreateConnection();
            if(Connection != null)
            {
                return await Connection.Table<TEntity>().ToListAsync();
            }            
            return new List<TEntity>();
        }

        public async override Task UpdateAsync( TEntity entity )
        {
            await CreateConnection();
            if(Connection != null)
            {
                await Connection.UpdateAsync( entity );
                OnEntityUpdated?.Invoke( this, entity );
            }
        }

        public async override Task DeleteAsync( int id )
        {
            TEntity entity = await GetAsync( id );
            if(Connection != null)
            {
                await Connection.DeleteAsync( entity );
                OnEntityDeleted?.Invoke( this, entity );
            }
        }

        protected override void FreeManagedResources() { }

        protected override void FreeUnmanagedResources()
        {
            Connection?.CloseAsync();
        }

        protected async Task CreateConnection()
        {
            if ( Connection != null )
            {
                return;
            }
            var documentPath = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData );
            var databasePath = Path.Combine( documentPath, _DB_FILE_NAME );
            Connection = new SQLiteAsyncConnection( databasePath, _FLAGS );
            await Connection.CreateTableAsync<TEntity>();
        }

        private const SQLiteOpenFlags _FLAGS =
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;

        protected SQLiteAsyncConnection? Connection { get; private set; }

        private const string _DB_FILE_NAME = "MeonMark.db";
    }
}