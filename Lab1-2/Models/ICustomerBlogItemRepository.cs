using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_2.Models
{
    public interface ICustomerBlogItemRepository
    {
        IList<BlogItem> FindByName(string namePattern);
        IList<BlogItem> FindPage(int page, int size);
        BlogItem FindById(int id);
    }

    class CustomerBlogItemRepository : ICustomerBlogItemRepository
    {
        ApplicationDbContext context;

        public CustomerBlogItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public BlogItem FindById(int id)
        {
            return context.BlogItems.Find(id);
        }

        public IList<BlogItem> FindByName(string namePattern)
        {
            return (from p in context.BlogItems where p.Title.Contains(namePattern) select p).ToList();
        }

        public IList<BlogItem> FindPage(int page, int size)
        {
            return (from p in context.BlogItems select p).OrderBy(p => p.Title).Skip((page - 1) * size).Take(size).ToList();
        }


    }
}
