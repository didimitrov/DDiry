using System.Data.Entity;
using Diary.Data.Migrations;
using Diary.Models;

namespace Diary.Data
{
   public class DiaryDbContext : DbContext
   {
       public DiaryDbContext() : base("DiaryDbContext")
       {
          Database.SetInitializer(new MigrateDatabaseToLatestVersion<DiaryDbContext, Configuration>()); 
       }

       public IDbSet<Story> Stories { get; set; }
       public IDbSet<MySelf> MySelf { get; set; }
   }
}
