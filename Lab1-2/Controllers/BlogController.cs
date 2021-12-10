using Lab1_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_2.Controllers
{
    public class BlogController : Controller
    {
        private ICRUDBlogItemRepository repository;

        public BlogController(ICRUDBlogItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public String Add()
        {
            var item = new BlogItem()
            {
                Content = "TEST",
                Title = "TEST"
            };
            item.Tags.Add(new Tag { Name = "C#" });
            item.Tags.Add(new Tag { Name = "ASP.NET" });
            repository.Save(item);
            return "New BlogItem Saved";
        }

        static List<BlogItem> items = new List<BlogItem>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddForm()
        {
            return View();
        }
        public IActionResult BlogList()
        {

            return View(items);
        }
        public IActionResult Add(BlogItem item)
        {
            if (ModelState.IsValid)
            {
                item = repository.Save(item);
                return View("Confirm", item);
            }

            return View();
        }

        

        public class BlogItemController : Controller
        {
            private ICRUDBlogItemRepository repository;

            public BlogItemController(ICRUDBlogItemRepository repository)
            {
                this.repository = repository;
            }

        }
    }
}
