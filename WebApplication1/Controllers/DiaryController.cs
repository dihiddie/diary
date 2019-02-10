using System;
using System.Collections.Generic;
using System.Web.Mvc;
using dihiddieDiary.DAL.DiaryPost.Core.Interfaces;
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
            return View(new List<PostViewModel>
            {
                new PostViewModel {Title = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Etiam interdum euismod sapien. Cras congue pellentesque commodo. Ut non condimentum metus", Id = 123, CreateDateTime = DateTime.Now, IsPreviewed = true, ImagePreviewPath = @"1.jpg", PreviewContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam interdum euismod sapien, eget tristique justo volutpat nec. Donec ullamcorper luctus urna, vitae fringilla mi euismod ac. In augue magna, venenatis eu urna ut, rhoncus fermentum sem. Sed felis purus, vehicula efficitur ipsum id, commodo fermentum ante. Maecenas eu venenatis erat. Nam venenatis neque sed enim sollicitudin, eget euismod arcu luctus. Vestibulum sed malesuada nunc. Curabitur euismod sodales nisl et ultrices. In vel accumsan quam. Aliquam erat volutpat. Phasellus tristique, tellus in finibus tempus, sapien metus gravida nisi, id euismod erat est eu nulla. Sed a justo arcu. Nullam non nulla laoreet, congue augue quis, efficitur purus. Duis fermentum semper mollis. Quisque tempus vitae sem in imperdiet. Nulla feugiat est in ligula congue, at pretium neque vehicula. Morbi molestie odio eget purus porta, id consequat lectus lobortis. Aenean vestibulum libero eu euismod fermentum. Sed quis massa eget nunc dignissim vulputate. Praesent dictum, ligula a pulvinar laoreet, massa massa tempor est, quis fermentum nunc nisl nec sem. Pellentesque sed eros nisi. Curabitur ante erat, maximus in nulla non, feugiat facilisis orci. Ut eu cursus urna. Cras congue pellentesque commodo. Ut non condimentum metus."},
                new PostViewModel {Title = "Lorem ipsum dolor sit amet", CreateDateTime = DateTime.Now, IsPreviewed = true, PreviewContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam interdum euismod sapien, eget tristique justo volutpat nec. Donec ullamcorper luctus urna, vitae fringilla mi euismod ac. In augue magna, venenatis eu urna ut, rhoncus fermentum sem. Sed felis purus, vehicula efficitur ipsum id, commodo fermentum ante. Maecenas eu venenatis erat. Nam venenatis neque sed enim sollicitudin, eget euismod arcu luctus. Vestibulum sed malesuada nunc. Curabitur euismod sodales nisl et ultrices. In vel accumsan quam. Aliquam erat volutpat. Phasellus tristique, tellus in finibus tempus, sapien metus gravida nisi, id euismod erat est eu nulla. Sed a justo arcu. Nullam non nulla laoreet, congue augue quis, efficitur purus. Duis fermentum semper mollis. Quisque tempus vitae sem in imperdiet. Nulla feugiat est in ligula congue, at pretium neque vehicula. Morbi molestie odio eget purus porta, id consequat lectus lobortis. Aenean vestibulum libero eu euismod fermentum. Sed quis massa eget nunc dignissim vulputate. Praesent dictum, ligula a pulvinar laoreet, massa massa tempor est, quis fermentum nunc nisl nec sem. Pellentesque sed eros nisi. Curabitur ante erat, maximus in nulla non, feugiat facilisis orci. Ut eu cursus urna. Cras congue pellentesque commodo. Ut non condimentum metus."},
                    new PostViewModel {Title = "Lorem ipsum dolor sit amet", CreateDateTime = DateTime.Now, IsPreviewed = false, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam interdum euismod sapien, eget tristique justo volutpat nec. Donec ullamcorper luctus urna, vitae fringilla mi euismod ac. In augue magna, venenatis eu urna ut, rhoncus fermentum sem. Sed felis purus, vehicula efficitur ipsum id, commodo fermentum ante. Maecenas eu venenatis erat. Nam venenatis neque sed enim sollicitudin, eget euismod arcu luctus. Vestibulum sed malesuada nunc. Curabitur euismod sodales nisl et ultrices. In vel accumsan quam. Aliquam erat volutpat. Phasellus tristique, tellus in finibus tempus, sapien metus gravida nisi, id euismod erat est eu nulla. Sed a justo arcu. Nullam non nulla laoreet, congue augue quis, efficitur purus. Duis fermentum semper mollis. Quisque tempus vitae sem in imperdiet. Nulla feugiat est in ligula congue, at pretium neque vehicula. Morbi molestie odio eget purus porta, id consequat lectus lobortis. Aenean vestibulum libero eu euismod fermentum. Sed quis massa eget nunc dignissim vulputate. Praesent dictum, ligula a pulvinar laoreet, massa massa tempor est, quis fermentum nunc nisl nec sem. Pellentesque sed eros nisi. Curabitur ante erat, maximus in nulla non, feugiat facilisis orci. Ut eu cursus urna. Cras congue pellentesque commodo. Ut non condimentum metus."}
            });
        }

        public ActionResult CreateOrEdit(int? postId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrEdit(PostViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Read(int postId)
        {
            return View(new PostViewModel { Title = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Etiam interdum euismod sapien. Cras congue pellentesque commodo. Ut non condimentum metus", Id = 123, CreateDateTime = DateTime.Now, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam interdum euismod sapien, eget tristique justo volutpat nec. Donec ullamcorper luctus urna, vitae fringilla mi euismod ac. In augue magna, venenatis eu urna ut, rhoncus fermentum sem. Sed felis purus, vehicula efficitur ipsum id, commodo fermentum ante. Maecenas eu venenatis erat. Nam venenatis neque sed enim sollicitudin, eget euismod arcu luctus. Vestibulum sed malesuada nunc. Curabitur euismod sodales nisl et ultrices. In vel accumsan quam. Aliquam erat volutpat. Phasellus tristique, tellus in finibus tempus, sapien metus gravida nisi, id euismod erat est eu nulla. Sed a justo arcu. Nullam non nulla laoreet, congue augue quis, efficitur purus. Duis fermentum semper mollis. Quisque tempus vitae sem in imperdiet. Nulla feugiat est in ligula congue, at pretium neque vehicula. Morbi molestie odio eget purus porta, id consequat lectus lobortis. Aenean vestibulum libero eu euismod fermentum. Sed quis massa eget nunc dignissim vulputate. Praesent dictum, ligula a pulvinar laoreet, massa massa tempor est, quis fermentum nunc nisl nec sem. Pellentesque sed eros nisi. Curabitur ante erat, maximus in nulla non, feugiat facilisis orci. Ut eu cursus urna. Cras congue pellentesque commodo. Ut non condimentum metus." });
        }
    }
}