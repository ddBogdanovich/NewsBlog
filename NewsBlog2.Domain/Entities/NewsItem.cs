using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System;

namespace NewsBlog2.Domain.Entities
{
    public class NewsItem
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }


   
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a headline")]
        public string Headline { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a news body")]
        public string Body { get; set; }

        public DateTime? Created { get; set; }


        [Required(ErrorMessage = "Please specify a category")]
        public NewsCategory Category { get; set; }

        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
    }
}
