using System.Data.Entity;
using Diary.Models;

namespace Diary.Data
{
   public class DiaryDbContext : DbContext
   {
       public DiaryDbContext() : base("DiaryDbContext")
       {
           
       }

       public IDbSet<Story> Stories { get; set; }
       public IDbSet<MySelf> MySelf { get; set; }
   }
}
