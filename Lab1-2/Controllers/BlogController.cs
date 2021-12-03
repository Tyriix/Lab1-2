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
        private ICrudBlogItemRepository repository;

        public BlogController(ICrudBlogItemRepository repository)
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

            return View(items);
        }
        public IActionResult Add(BlogItem item)
        {
            items.Add(item);
            return View("ConfirmBlogItem", item);
        }
    }
}
