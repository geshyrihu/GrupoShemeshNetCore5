using GrupoShemesh.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Infrastructure.Services
{
    public interface IComboBox<T> where T : class
    {
        Task<IEnumerable<T>> GetAsyncAll(T entity);
    }

    public class ComboBox<T> : IComboBox<T> where T : class
    {

        private readonly IUnitOfWork _unitOfWork;
        public ComboBox(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<T>> GetAsyncAll(T entity)
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }
    }
}
