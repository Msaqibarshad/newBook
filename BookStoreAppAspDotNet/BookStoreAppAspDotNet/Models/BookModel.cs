using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookStoreAppAspDotNet.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter The Title Of Your Book*")]
        [StringLength(50, MinimumLength =5)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter The Author Name*")]
        
        public string Author { get; set; }

        
        [StringLength(500, MinimumLength =30)]

        public string Description { get; set; }

        public string Category { get; set; }
         [Required(ErrorMessage = "Please Choose The Language Of Your Book*")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Please Enter The Total Pages of your Book*")]

        public int? Pages { get; set; }

        [Display(Name ="Choose the Cover photo of your book")]
        [Required(ErrorMessage = "Please Choose the Cover photo of your book*")]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }


    }
}
