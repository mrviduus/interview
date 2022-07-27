using GraduationTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.DataAccess
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(
            Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>,
            IOrderedEnumerable<TEntity>> orderBy = null);

        TEntity GetByID(int id);
    }
}
