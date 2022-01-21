using Lab1_2.Controllers;
using Lab1_2.Models;
using System;
using Xunit;

namespace Lab1_2_Test_Project
{
    public class UnitTest1
    {
        
        [Fact]
        public void Add()
        {
            //Given
            ICRUDBlogItemRepository blogs = new MemoryBlogRepository();
            ApiBlogController controller = new ApiBlogController(blogs);
            BlogItem item = new BlogItem();

            //When
            controller.Add(item);

            //That
            //Assert.Equal(blogs.FindById(1));
        }
    }
}
