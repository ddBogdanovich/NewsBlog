using NewsBlog2.Domain.Entities;
namespace NewsBlog2.Domain
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=EFDbContext")
        {
        }
    
        public DbSet<NewsItem> News { get; set; }
        public DbSet<NewsCategory> Categories { get; set; }
    }

  
}