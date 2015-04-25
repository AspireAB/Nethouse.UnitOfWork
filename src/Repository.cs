using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Nethouse.UnitOfWork
{
    public abstract class Repository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private IDbSet<T> _items;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected IDbSet<T> Items
        {
            get { return _items ?? (_items = _unitOfWork.Set<T>()); }
        }

        public virtual T Create(bool add = true)
        {
            var item = Items.Create();
            return add ? Add(item) : item;
        }

        public virtual T Add(T item)
        {
            return Items.Add(item);
        }

        public virtual T Reload(T item)
        {
            _unitOfWork.Reload(item);
            return item;
        }

        public virtual T Remove(T item)
        {
            return Items.Remove(item);
        }

        public virtual void Remove(IEnumerable<T> items)
        {
            foreach (var item in items.ToList())
            {
                Remove(item);
            }
        }
    }
}