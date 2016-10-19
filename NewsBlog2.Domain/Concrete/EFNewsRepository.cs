using System;
using System.Collections.Generic;
using NewsBlog2.Domain.Abstract;
using NewsBlog2.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace NewsBlog2.Domain.Concrete
{
    public class EFNewsRepository : INewsRepository
    {
        private EFDbContext ctx = new EFDbContext();


        public IEnumerable<NewsCategory> ActualCategories//TODO Check in profiler
        {
            get
            {
                return ctx.News.Include("Category").Select(x => x.Category).Distinct();
            }
        }

        public IEnumerable<NewsCategory> AllCategories
        {
            get
            {
                return ctx.Categories;
            }
        }

        public IEnumerable<NewsItem> News
        {
            get
            {
                return ctx.News.Include("Category").OrderBy(n => n.Created);
            }
        }

        public NewsItem DeleteNewsItem(int itemId)   // TODO Check...
        {
            NewsItem dbEntry = ctx.News.Find(itemId);
            if(dbEntry != null)
            {
                ctx.News.Remove(dbEntry);
                ctx.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveNewsItem(NewsItem item)  // TODO Check...
        {
            if(item.ID == 0)
            {
                item.Created = DateTime.Now;
                ctx.News.Add(item);
            }
            else
            {
                NewsItem dbEntry = ctx.News.Find(item.ID);
                if(dbEntry != null)
                {
                    dbEntry.Headline = item.Headline;
                    dbEntry.Category = item.Category;
                    dbEntry.Body = item.Body;
                    dbEntry.Created = item.Created;
                }

            }
            ctx.SaveChanges();
        }

        public void SaveCategoryItem(NewsCategory cat)
        {
            if (cat.Id == 0)
            {
               ctx.Categories.Add(cat);
            }
            else
            {
                NewsCategory dbEntry = ctx.Categories.Find(cat.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = cat.Name;
                  
                }

            }
            ctx.SaveChanges();
        }


    }
}
