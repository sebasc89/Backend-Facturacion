using DigitalWare.Facturacion.Common.Classes.Constants;
using DigitalWare.Facturacion.Common.Classes.DTO.Request;
using DigitalWare.Facturacion.Common.Classes.Helpers;
using DigitalWare.Facturacion.Common.Classes.Helpers.DinamycFilters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Common.Classes.Base.Repositories
{
    public interface IBaseCRUDRepository<TEntity> : ICreateRepository<TEntity>,
        IReadRepository<TEntity>, IUpdateRepository<TEntity>, IDeleteRepository<TEntity>
        where TEntity : class
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }

    public abstract class BaseCRUDRepository<TEntity> : IBaseCRUDRepository<TEntity>
        where TEntity : class
    {
        protected DbContext _Database;
        protected DbSet<TEntity> _Table;

        public BaseCRUDRepository(DbContext context)
        {
            _Database = context;
            _Table = _Database.Set<TEntity>();
        }

        #region Async CRUD

        public async Task<TEntity> CreateAsync(TEntity entity, bool autoSave = true)
        {
            await _Table.AddAsync(entity);
            if (autoSave)
            {
                await SaveChangesAsync();
            }

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = true)
        {
            var oldItem = await FindByIdAsync(GetValuePrimaryKey(entity));

            _Database.Entry(oldItem).CurrentValues.SetValues(entity);
            if (autoSave)
            {
                await SaveChangesAsync();
            }
            return entity;
        }

        public virtual async Task<TEntity> FindByIdAsync(object id)
        {
            var newId = CastPrimaryKey(id);
            return await _Table.FindAsync(newId);
        }

        public async Task DeleteAsync(TEntity entity, bool autoSave = true)
        {
            _Table.Remove(entity);

            if (autoSave)
            {
                await SaveChangesAsync();
            }
        }

        #endregion

        #region CRUD
        public virtual TEntity Create(TEntity entity, bool autoSave = true)
        {
            _Table.Add(entity);

            if (autoSave)
            {
                _Database.SaveChanges();
            }

            return entity;
        }

        public virtual TEntity Update(TEntity entity, bool autoSave = true)
        {
            if (entity == null)
            {
                return null;
            }
            TEntity exist = _Table.Find(GetValuePrimaryKey(entity));
            if (exist != null)
            {
                _Database.Entry(exist).CurrentValues.SetValues(entity);
                if (autoSave)
                {
                    _Database.SaveChanges();
                }
            }

            return exist;
        }

        public virtual void Delete(TEntity entity, bool autoSave = true)
        {
            _Table.Remove(entity);
            if (autoSave)
            {
                _Database.SaveChanges();
            }
        }

        public virtual TEntity FindById(object id)
        {
            var newId = CastPrimaryKey(id);
            return _Table.Find(newId);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _Table;
        }

        #endregion

        #region Pagination
        public virtual IQueryable<TEntity> GetAllPaging(int pageIndex, int pageSize)
        {

            return _Table.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public virtual PagedList<TEntity> GetAllPaged(PagingParams pagingParams)
        {
            Expression<Func<TEntity, bool>> whereDelegate = ExpressionBuilder.GetExpression<TEntity>(pagingParams.Filters);
            return new PagedList<TEntity>(GetAll(), whereDelegate, pagingParams);
        }

        #endregion


        public async virtual Task SaveChangesAsync()
        {
            await _Database.SaveChangesAsync();
        }

        public virtual void SaveChanges()
        {
            _Database.SaveChanges();
        }

        #region Others
        protected string GetPrimaryKeyName()
        {
            var keyNames = _Database.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name);
            string keyName = keyNames.FirstOrDefault();

            if (keyNames.Count() > 1)
            {
                throw new ApplicationException(GlobalConstants.ERROR_BASE_MODEL_ONLY_ONE_KEY);
            }

            if (keyName == null)
            {
                throw new ApplicationException(GlobalConstants.ERROR_BASE_MODEL_PRIMARY_KEY);
            }

            return keyName;
        }

        protected object CastPrimaryKey(object id)
        {
            string keyName = GetPrimaryKeyName();
            Type keyType = typeof(TEntity).GetProperty(keyName).PropertyType;
            return Convert.ChangeType(id, keyType);
        }

        protected object GetValuePrimaryKey(TEntity entity)
        {
            string keyName = GetPrimaryKeyName();
            object value = typeof(TEntity).GetProperty(keyName).GetValue(entity);
            return value;
        }

        #endregion
    }
}
