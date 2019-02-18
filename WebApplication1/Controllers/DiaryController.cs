using System.Web.Mvc;
using dihiddieDiary.DAL.DiaryPost.Core.Interfaces;
using dihiddieDiary.DAL.DiaryPost.Core.Models;
using dihiddieDiary.Models.Diary;

namespace dihiddieDiary.Controllers
{
    public class DiaryController : Controller
    {
        private readonly IDiaryUnitOfWork diaryUnitOfWork;

        public DiaryController(IDiaryUnitOfWork unitOfWork) => diaryUnitOfWork = unitOfWork;

        // GET: Diary
        public ActionResult Index()
        {
            var posts = diaryUnitOfWork.DiaryRepository.GetPreviews(15, 0);
            return View(AutoMapper.Mapper.Map<PostViewModel[]>(posts));
        }

        public ActionResult CreateOrEdit(int? postId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrEdit(PostViewModel model)
        {
            diaryUnitOfWork.DiaryRepository.SavePost(AutoMapper.Mapper.Map<DiaryPost>(model));
            diaryUnitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Read(int postId)
        {            
            return View(AutoMapper.Mapper.Map<PostViewModel>(diaryUnitOfWork.DiaryRepository.GetPost(postId)));
        }
    }
}