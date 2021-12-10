using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_2.Models
{

    public interface ICRUDBlogItemRepository
    {
        BlogItem Find(int id);
        BlogItem Delete(int id);
        BlogItem Add(BlogItem blogItem);
        BlogItem Update(BlogItem blogItem);

        BlogItem Save(BlogItem blogItem);

        IList<BlogItem> FindAll();

        void addTagToBlogItem(int blogItemId, int tagId);
    }

    
    class EFBlogItemRepository : ICRUDBlogItemRepository
    {
        private ApplicationDbContext _context;

        public EFBlogItemRepository(ApplicationDbContext context)
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

        public BlogItem Save(BlogItem item)
        {
            var entryEntity = _context.BlogItems.Add(item);
            _context.SaveChanges();
            return entryEntity.Entity;
        }
        public IList<BlogItem> FindAll()
        {
            return _context.BlogItems.ToList();
        }
        public void addTagToBlogItem(int blogItemId, int tagId)
        {
            var item = _context.BlogItems.Find(blogItemId);
            var tag = _context.Tags.Find(tagId);
            item.Tags.Add(tag);
            Update(item);
        }
    }
}
