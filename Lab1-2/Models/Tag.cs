using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
