using System.Collections.Generic;
using System.Linq;

namespace Lab1_2.Models
{
    public interface ICRUDBlogItemRepository
    {
        void Delete(int id);

        BlogItem Update(BlogItem blogItem);

        BlogItem FindById(int id);

        BlogItem Save(BlogItem blogItem);

        IList<BlogItem> FindPage(int page, int size);

        IList<BlogItem> FindAll();

        void AddTagToBlogItem(int blogItemId, int tagId);

        IQueryable<BlogItem> BlogItems { get; }
    }
}