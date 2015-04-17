using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Diary.Models;
using Diary.Web.Infrastructure;

namespace Diary.Web.Models
{
    public class StoryInfo : IMapFrom<Story>
    {
        //public StoryInfo()
        //{
        //    StoryDate = DateTime.Now;
        //}

        [Key]
        public int StoryId { get; set; }
        [Required(ErrorMessage="Моля, задайте заглавие")]
        [Display(Name="Заглавие")]
        public string Title { get; set; }
        [Required(ErrorMessage="Моля,задаите дата")]
        [Display(Name="Дата")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StoryDate { get; set; }
        [Range(0,6)]
        [Display(Name="Рейтинг на историята")]
        public int Rate { get; set; }
        [Required(ErrorMessage = "Трябва да се попълни текст към историята")]
        [Display(Name="Текст")]
        public string StoryText { get; set; }
        [Display(Name = "Файл за снимка на събитието")]
        public HttpPostedFileBase  PostedFile { get; set; }
        public string ImageUrl { get; set; }
        public string Search { get; set; }
    }
}