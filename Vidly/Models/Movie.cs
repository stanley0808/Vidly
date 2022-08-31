using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "上映日期")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name = "庫存數量")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
        [Display(Name = "電影種類")]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

    }


}