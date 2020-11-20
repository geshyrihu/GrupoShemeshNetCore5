using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrupoShemesh.Infrastructure.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsyncById(int id);
        Task<T> GetAsyncById(string id);
        Task<IEnumerable<T>> GetAsyncAll(Expression<Func<T, bool>> whereCondition = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<IEnumerable<T>> GetAsyncAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<IEnumerable<T>> GetAsyncAll(Expression<Func<T, bool>> whereCondition = null);
        Task<IEnumerable<T>> GetAsyncAll(Expression<Func<T, bool>> whereCondition = null,
                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                   string includeProperties = "");
        Task<T> CreateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<T> DeleteAsync(T entity);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition = null);

        Task<T> UpdateAsync(T entity);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<T> GetAsyncById(int id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetAsyncById(string id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }
       
        public async Task<IEnumerable<T>> GetAsyncAll(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();
            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAsyncAll(Expression<Func<T, bool>> whereCondition = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();
            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAsyncAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();
            return await orderBy(query).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsyncAll(Expression<Func<T, bool>> whereCondition = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();
            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            return await query.ToListAsync();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _unitOfWork.Context.AddAsync(entity);
            await _unitOfWork.Context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            await _unitOfWork.Context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _unitOfWork.Context.Set<T>().Remove(entity);
            await _unitOfWork.Context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> DeleteAsync(T entity)
        {
            _unitOfWork.Context.Set<T>().Remove(entity);
            await _unitOfWork.Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            return await query.FirstOrDefaultAsync(whereCondition);
        }


    }
}
