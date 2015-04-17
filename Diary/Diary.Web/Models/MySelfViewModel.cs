using System;
using System.ComponentModel.DataAnnotations;
using Diary.Models;
using Diary.Web.Infrastructure;

namespace Diary.Web.Models
{
    public class MySelfViewModel:IMapFrom<MySelf>
    {
        public int MySelfId { get; set; }
        [Required(ErrorMessage = "Моля,въведете име!")]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Display(Name = "Рожденна дата")]
        [DataType(DataType.DateTime)]
        public DateTime Born { get; set; }
        [Display(Name = "Информация")]
        public string Info { get; set; }
        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; }
    }
}