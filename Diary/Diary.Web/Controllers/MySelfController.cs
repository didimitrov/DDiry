using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Diary.Data.Repository;
using Diary.Models;
using Diary.Web.Models;

namespace Diary.Web.Controllers
{
    public class MySelfController : Controller
    {
        private readonly IRepository<MySelf> _mySelf; 
        // GET: MySelf
        public MySelfController(IRepository<MySelf> mySelf)
        {
            this._mySelf = mySelf;
        }
        public ActionResult Index()
        {
            var me = _mySelf.All()
                .Project()
                .To<MySelfViewModel>().ToList();
            return View(me);
        }
    }
    
}