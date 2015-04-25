using System;
using System.Collections.Concurrent;
using System.Data.Entity;

namespace Nethouse.UnitOfWork
{
    public class TestUnitOfWork : IUnitOfWork
    {
        private readonly ConcurrentDictionary<Type, object> _sets = new ConcurrentDictionary<Type, object>();

        public DbSet<T> Set<T>() where T : class
        {
            var set = _sets.GetOrAdd(typeof (T), t => new TestDbSet<T>(this));
            return (DbSet<T>) set;
        }

        public int SaveChanges()
        {
            //Intentionally left blank
            return 0;
        }

        public void Reload<T>(T entity) where T : class
        {
            //Intentionally left blank
        }
    }
}