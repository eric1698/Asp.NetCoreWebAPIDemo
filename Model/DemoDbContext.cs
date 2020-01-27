using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Entity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext (DbContextOptions<DemoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var dd = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes() ).Where(t => t.Name ==  typeof(IEntityTypeConfiguration<>).Name);
            modelBuilder.ApplyConfiguration(new ContentConfiguration());

        }

        public DbSet<Content> Content { get; set; }

    }
}
