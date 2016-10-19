using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsBlog2.Domain.Abstract;
using NewsBlog2.Domain.Entities;
using NewsBlog2.Models;
using System.Data.Entity;


namespace NewsBlog2.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository repository;

        public int Pagesize = 5;
        public NewsController(INewsRepository repo)
        {
            repository = repo;
        }
        
        public ActionResult List(string category, int page = 1)
        {
            NewsListViewModel model = new NewsListViewModel
            {
                News = repository.News
                 .Where(n => category == null || n.Category.Name == category)
                 .OrderBy(n => n.Created)
                 .Skip((page - 1) * Pagesize)
                 .Take(Pagesize),
                  

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = Pagesize,
                    TotalItems =  category == null ? repository.News.Count() :
                    repository.News.Where(e => e.Category.Name == category).Count()
                },

               // Categories = repository.ActualCategories.ToList(),
                CurrentCategory = category
            };
            return View(model);
            
        }
    }
}