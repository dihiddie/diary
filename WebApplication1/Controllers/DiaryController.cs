using System.Collections.Generic;
using System.Web.Mvc;
using dihiddieDiary.Models.Diary;

namespace dihiddieDiary.Controllers
{
    public class DiaryController : Controller
    {
        // GET: Diary
        public ActionResult Index()
        {
            return View(new List<PostViewModel> {new PostViewModel {Title = "1"}, new PostViewModel {Title = "2"}, new PostViewModel {Title = "3"}});
        }

        public ActionResult CreateOrEdit(int? postId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrEdit(PostViewModel model)
        {
            return View("Index");
        }
    }
}