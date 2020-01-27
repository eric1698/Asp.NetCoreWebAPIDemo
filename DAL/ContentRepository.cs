using IDAL;
using Model;
using System;
namespace DAL
{
    public class ContentRepository : RepositoryBase<Content>, IContentRepository
    {
        DemoDbContext dbContext;

        public ContentRepository(DemoDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void UpdatePartial(Content content)
        {
            content.ModifyTime = DateTime.Now;
            dbContext.Entry(content).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.Entry(content).Property(m => m.CreateTime).IsModified = false;
        }
    }
}
