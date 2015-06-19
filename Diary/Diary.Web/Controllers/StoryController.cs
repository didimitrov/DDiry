using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Diary.Data.Repository;
using Diary.Models;
using Diary.Web.Models;

namespace Diary.Web.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        private readonly IRepository<Story> _story;
        public StoryController(IRepository<Story> story)
        {
            this._story = story;
        }

        // GET: Story 
        public ActionResult Index()
        {
            var allStories = _story.All().OrderBy(x => x.StoryDate)
                .Project()
                .To<StoryInfo>();
            return View(allStories);
        }

        //[HttpPost]
        //public ActionResult Index(string txtSearch)
        //{
        //    var allStories = _story.All()
        //        .Where(x => x.Title.Contains(txtSearch) || x.StoryText.Contains(txtSearch)).OrderBy(x => x.StoryDate)
        //        .Project()
        //        .To<StoryInfo>();
        //    return View(allStories);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryInfo st)
        {
            var fileName = "";
            var path = "";
            if (ModelState.IsValid)
            {
                if (st.PostedFile.ContentLength > 0)
                {
                    fileName = System.IO.Path.GetFileName(st.PostedFile.FileName);
                    path = System.IO.Path.Combine(Server.MapPath("~/Content/Pictures/"), fileName);
                    st.PostedFile.SaveAs(path);
                }
                var storyEntity = new Story
                {
                    StoryText = st.StoryText,
                    StoryDate = st.StoryDate,
                    Title = st.Title,
                    Rate = st.Rate,
                    ImageUrl = fileName
                };
                this._story.Add(storyEntity);
                this._story.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View(st);
        }

        public ActionResult Delete(int Id)
        {
            var storyEntity = _story.All().FirstOrDefault(x => x.StoryId == Id);
            var path = System.IO.Path.Combine(Server.MapPath("~/Content/Pictures/"), storyEntity.ImageUrl);
            System.IO.File.Delete(path);
            _story.Delete(storyEntity);
            _story.SaveChanges();
            return RedirectToAction("Index");
            ;
        }

        public ActionResult Slide()
        {
            var allStories = _story.All().OrderBy(x => x.StoryId)
                  .Project()
                  .To<StoryInfo>();
            var minId = _story.All()
                .Min(x => x.StoryId);
            ViewBag.MinStoryID = minId;
            return View(allStories);
        }
    }
}