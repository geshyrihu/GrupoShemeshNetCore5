using GrupoShemesh.Data;
using System;

namespace GrupoShemesh.Infrastructure.Services
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
