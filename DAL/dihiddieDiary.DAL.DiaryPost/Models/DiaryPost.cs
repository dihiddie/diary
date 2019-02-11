using System;

namespace dihiddieDiary.DAL.DiaryPost.Core.Models
{
    public class DiaryPost
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] Content { get; set; }

        public string PreviewContent { get; set; }
    }
}
