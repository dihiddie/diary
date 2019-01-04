using System.ComponentModel.DataAnnotations;

namespace dihiddieDiary.Models.Diary
{
    public sealed class PostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}