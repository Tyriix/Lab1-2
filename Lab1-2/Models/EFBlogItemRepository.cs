using System.Collections.Generic;
using System.Linq;

namespace Lab1_2.Models
{
    internal class EFBlogItemRepository : ICRUDBlogItemRepository
    {
        private ApplicationDbContext _context;

        public EFBlogItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<BlogItem> BlogItems => _context.BlogItems;

        public BlogItem FindById(int id)
        {
            return _context.BlogItems.Find(id);
        }

        public void Delete(int id)
        {
            var blogItem = _context.BlogItems.Remove(FindById(id)).Entity;
            _context.SaveChanges();
        }

        //public BlogItem Add(BlogItem blogItem)
        //{
        //    var entity = _context.BlogItems.Add(blogItem).Entity;
        //    _context.SaveChanges();
        //    return entity;
        //}

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

        public IList<BlogItem> FindPage(int page, int size)
        {
            return (from item in _context.BlogItems orderby item.CreationTimestamp select item)
                .Skip(page * size)
                .Take(size)
                .ToList();
        }

        public void AddTagToBlogItem(int blogItemId, int tagId)
        {
            var item = _context.BlogItems.Find(blogItemId);
            var tag = _context.Tags.Find(tagId);
            item.Tags.Add(tag);
            Update(item);
        }
    }
}