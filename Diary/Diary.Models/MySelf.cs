using System;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models
{
    public class MySelf
    {
        [Key]
        public int MySelfId { get; set; }
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public string Info { get; set; }
        public string ImageUrl { get; set; }

    }
}
