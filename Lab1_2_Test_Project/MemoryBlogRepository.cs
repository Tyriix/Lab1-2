using Lab1_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2_Test_Project
{
    class MemoryBlogRepository : ICRUDBlogItemRepository
    {
        public IQueryable<BlogItem> BlogItems => throw new NotImplementedException();
        private Dictionary<int, BlogItem> items = new Dictionary<int, BlogItem>();
        private int Index = 1;
        private int nextIndex()
        {
            return ++Index;
        }
        private BlogItem Add(BlogItem blogItem)
        {
            blogItem.Id = nextIndex();
            items.Add(blogItem.Id, blogItem);
            return blogItem;
        }
        public void AddTagToBlogItem(int blogItemId, int tagId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<BlogItem> FindAll()
        {
            return items.Values.ToList();
        }

        public BlogItem FindById(int id)
        {
            return items[id];
        }

        public IList<BlogItem> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public BlogItem Save(BlogItem blogItem)
        {
            throw new NotImplementedException();
        }

        public BlogItem Update(BlogItem blogItem)
        {
            throw new NotImplementedException();
        }
    }
}
