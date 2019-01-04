using System.Web.Mvc;

namespace dihiddieDiary.Controllers
{
    public class DiaryController : Controller
    {
        // GET: Diary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrEdit(int? postId)
        {
            return View();
        }
    }
}