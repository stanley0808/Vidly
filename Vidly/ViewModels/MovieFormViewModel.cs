using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "電影名稱")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "上映日期")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "庫存數量")]
        [NumberInStockNotIn20]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public string title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        //預設ID=0，判斷是否為資料庫帶出來的值，因為新增的資料並不會有ID的值。
        public MovieFormViewModel()
        {
            Id = 0;
        }
        //有ID的值的話，才會從資料庫裡面抓取資料，去讀取資料庫裏面的舊資料，適用於修改的情況
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}