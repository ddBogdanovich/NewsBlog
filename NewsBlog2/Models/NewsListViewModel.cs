using System.Collections.Generic;
using NewsBlog2.Domain.Entities;

namespace NewsBlog2.Models
{
    public class NewsListViewModel
    {
        public IEnumerable<NewsItem> News { get; set; }

        public IEnumerable<NewsCategory> Categories { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}