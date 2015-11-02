using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Diary.Data.Repository;
using Diary.Models;
using Diary.Web.Models;
using PagedList;

namespace Diary.Web.Controllers
{
    public class StoryController : Controller
    {
        private readonly IRepository<Story> _story;

        public StoryController(IRepository<Story> story)
        {
            _story = story;
        }

        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {
            var stories = _story.All().OrderBy(x => x.StoryDate)
               .Project()
                .To<StoryViewModel>();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        
            switch (sortOrder)
            {
                case "title_desc":
                    stories = stories.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    stories = stories.OrderBy(s => s.StoryDate);
                    break;
                case "date_desc":
                    stories = stories.OrderByDescending(s => s.StoryDate);
                    break;
                default:
                    stories = stories.OrderByDescending(s => s.StoryDate);
                    break;
            }

            const int pageSize = 2;
            var pageNumber = (page ?? 1);
            return View(stories.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var allStories = _story.All()
                .Where(x => x.Title.Contains(searchString) || x.StoryText.Contains(searchString)).OrderBy(x => x.StoryDate)
                .Project()
                .To<StoryViewModel>();
            return View(allStories.ToPagedList(1,2));
        }

        // GET: Story 
        //public ActionResult Index()
        //{
        //    const int pageSize = 2;

        //    var allStories = _story.All().OrderBy(x => x.StoryDate)
        //        .Project()
        //        .To<StoryInfo>();
        //    return View(allStories.ToPagedList(1, pageSize));
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryViewModel story)
        {
            var fileName = "";
            if (ModelState.IsValid)
            {
                if (story.PostedFile.ContentLength > 0)
                {
                    fileName = System.IO.Path.GetFileName(story.PostedFile.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/Pictures/"), fileName);
                    story.PostedFile.SaveAs(path);
                }
                var storyEntity = new Story
                {
                    StoryText = story.StoryText,
                    StoryDate = story.StoryDate,
                    Title = story.Title,
                    Rate = story.Rate,
                    ImageUrl = fileName
                };
                _story.Add(storyEntity);
                _story.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View(story);
        }

        public ActionResult Delete(int Id)
        {
            var storyEntity = _story.All().FirstOrDefault(x => x.StoryId == Id);
            var path = System.IO.Path.Combine(Server.MapPath("~/Content/Pictures/"), storyEntity.ImageUrl);
            System.IO.File.Delete(path);
            _story.Delete(storyEntity);
            _story.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult Slide()
        {
            var allStories = _story.All().OrderBy(x => x.StoryId)
                  .Project()
                  .To<StoryViewModel>();
            var minId = _story.All()
                .Min(x => x.StoryId);
            ViewBag.MinStoryID = minId;
            return View(allStories);
        }
    }
}