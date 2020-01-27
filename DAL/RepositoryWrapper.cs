using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private DemoDbContext dbContext;
        private IContentRepository contentRepository;

        public RepositoryWrapper(DemoDbContext demoDbContext)
        {
            dbContext = demoDbContext;
        }

        public IContentRepository Content
        {
            get
            {
                if (contentRepository == null)
                    contentRepository = new ContentRepository(dbContext);
                return contentRepository;
            }
        }

        public Task<int> SaveChanges()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
