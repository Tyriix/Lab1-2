using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_2.Models
{
    public class BlogItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationTimstamp { get; set; }

    }
    public interface IBlogItemRepository
    {
        IQueryable<BlogItem> BlogItems { get; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BlogItem> BlogItems { get; set; }
    }
    
    public class EFBlogItemRepository : IBlogItemRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public EFBlogItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<BlogItem> BlogItems => _applicationDbContext.BlogItems;
    }


    public interface ICrudBlogItemRepository
    {
        BlogItem Find(int id);
        BlogItem Delete(int id);
        BlogItem Add(BlogItem blogItem);
        BlogItem Update(BlogItem blogItem);

        IList<BlogItem> FindAll();
    }

    class CrudBlogItemRepository : ICrudBlogItemRepository
    {
        private ApplicationDbContext _context;

        public CrudBlogItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BlogItem Find(int id)
        {
            return _context.BlogItems.Find(id);
        }

        public BlogItem Delete(int id)
        {
            var blogItem = _context.BlogItems.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return blogItem;
        }

        public BlogItem Add(BlogItem blogItem)
        {
            var entity = _context.BlogItems.Add(blogItem).Entity;
            _context.SaveChanges();
            return entity;
        }

        public BlogItem Update(BlogItem blogItem)
        {
            var entity = _context.BlogItems.Update(blogItem).Entity;
            _context.SaveChanges();
            return entity;
        }

        public IList<BlogItem> FindAll()
        {
            return _context.BlogItems.ToList();
        }
    }   

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
