using System;
using System.Collections.Generic;
using NewsBlog2.Domain.Entities;
namespace NewsBlog2.Domain.Abstract
{
    public interface INewsRepository
    {
        IEnumerable<NewsItem> News { get; }

        IEnumerable<NewsCategory> AllCategories { get; }

        IEnumerable<NewsCategory> ActualCategories { get; }

        void SaveNewsItem(NewsItem item);

        void SaveCategoryItem(NewsCategory cat);

        NewsItem DeleteNewsItem(int itemId);


    }
}
