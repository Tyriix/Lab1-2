using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1_2.Models
{
    public class BlogItem
    {
        public BlogItem()
        {
            Tags = new HashSet<Tag>();
        }

        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Musisz wpisać treść")]
        [MinLength(5, ErrorMessage = "Treść powinna zawierać conajmniej 5 znaków")]
        public string Content { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public ICollection<Tag> Tags { get; set; }
        
    }
}