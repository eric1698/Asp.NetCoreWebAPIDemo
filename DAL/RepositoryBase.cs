using IDAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T :class
    {
        private DemoDbContext dbContext { get; set; }

        public RepositoryBase(DemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T source)
        {
           dbContext.Set<T>().Add(source);
        }

        public void Delete(int id)
        {
            var entity = dbContext.Set<T>().Find(id);
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<T>>Reads(Expression<Func<T, bool>> predicate)
        {           
            return await dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public void Update(T source)
        {            
            dbContext.Entry(source).State = EntityState.Modified;
        }
    }
}
