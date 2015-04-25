using System.Data.Entity;

namespace Nethouse.UnitOfWork
{
    public interface IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();       
    }
}