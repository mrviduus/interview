using GraduationTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private IEnumerable<TEntity> context;
        public Repository(IEnumerable<TEntity> context)
        {
            this.context = context;
        }
        public virtual IEnumerable<TEntity> Get(
            Func<TEntity, bool> filter = null,
            Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null)
        {
            if (filter != null)
            {
                context = context.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(context).ToList();
            }
            else
            {
                return context.ToList();
            }
        }

        public virtual TEntity GetByID(int id) => context.ToList().Find(x => x.Id == id);
    }
}
