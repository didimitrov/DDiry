using System;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models
{
    public class Story
    {
        [Key]
        public int StoryId { get; set; }
        public string Title { get; set; }
        public string StoryText { get; set; }
        public DateTime StoryDate { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }
}
