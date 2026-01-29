using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BaseService<T> where T : class
    {
        protected readonly BaseRepo<T> _repo;

        public BaseService(BaseRepo<T> repo)
        {
            _repo = repo;
        }

        #region Read

        public virtual List<T> GetAll()
        {
            return _repo.GetAll();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public virtual T GetById(int id)
        {
            return _repo.GetById(id);
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public virtual T GetById(string code)
        {
            return _repo.GetById(code);
        }

        public virtual Task<T> GetByIdAsync(string code)
        {
            return _repo.GetByIdAsync(code);
        }

        public virtual T GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public virtual Task<T> GetByIdAsync(Guid id)
        {
            return _repo.GetByIdAsync(id);
        }

        #endregion

        #region Create

        public virtual T Create(T entity)
        {
            _repo.Create(entity);
            return entity;
        }

        public virtual Task<T> CreateAsync(T entity)
        {
            return _repo.CreateAsync(entity);
        }

        #endregion

        #region Update

        public virtual T Update(T entity)
        {
            _repo.Update(entity);
            return entity;
        }

        public virtual Task<T> UpdateAsync(T entity)
        {
            return _repo.UpdateAsync(entity);
        }

        #endregion

        #region Delete

        public virtual bool Remove(T entity)
        {
            return _repo.Remove(entity);
        }

        public virtual Task<bool> RemoveAsync(T entity)
        {
            return _repo.RemoveAsync(entity);
        }

        #endregion
    }
}
