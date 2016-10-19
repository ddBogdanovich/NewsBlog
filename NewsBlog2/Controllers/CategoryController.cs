using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsBlog2.Domain.Abstract;

namespace NewsBlog2.Controllers
{
    public class CategoryController : Controller
    {
        
            private INewsRepository repository;

            public CategoryController(INewsRepository repo)
            {
                repository = repo;
            }

            public ActionResult CategoryList(string category = null)
            {
                ViewBag.SelectedCategory = category;
                IEnumerable<string> categories = repository.ActualCategories.Select(c => c.Name).ToList();  //???

                return PartialView("FlexMenu", categories);
            }
        }
    }
