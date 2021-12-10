using System.Collections.Generic;

namespace Lab1_2.Models
{
    public class Tag
    {
        public Tag()
        {
            BlogItems = new HashSet<BlogItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BlogItem> BlogItems;
    }
}