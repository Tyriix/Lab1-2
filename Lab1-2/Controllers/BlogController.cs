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

            return View(repository.FindAll());
        }
        public IActionResult Add(BlogItem item)
        {
            if (ModelState.IsValid)
            {
                item = repository.Save(item);
                return View("ConfirmBlogItem", item);
            }
            else
            {
                return View("AddForm");
            }
            
        }
        public IActionResult Edit(int Id)
        {
            return View("Edit", repository.FindById(Id));
        }

        [HttpPost]
        public IActionResult Edit(BlogItem item)
        {
            repository.Update(item);
            return View("BlogList", repository.FindAll());
        }

        public IActionResult Delete(BlogItem item)
        {
            repository.Delete(item.Id);
            return View("BlogList", repository.FindAll());
        }

        public IActionResult Details(BlogItem item)
        {
            item = repository.FindById(item.Id);
            return View(item);
        }
        //[HttpPost]
        //public String AddTest()
        //{
        //    var item = new BlogItem()
        //    {
        //        Content = "TESTB",
        //        Title = "TESTB"
        //    };
        //    item.Tags.Add(new Tag { Name = "C#" });
        //    item.Tags.Add(new Tag { Name = "ASP.NET" });
        //    repository.Save(item);
        //    return "New BlogItem Saved";
        //}
        //public class BlogItemController : Controller
        //{
        //    private ICRUDBlogItemRepository repository;

        //    public BlogItemController(ICRUDBlogItemRepository repository)
        //    {
        //        this.repository = repository;
        //    }

        //}
    }
}
