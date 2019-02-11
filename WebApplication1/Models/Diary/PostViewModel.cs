using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using dihiddieDiary.Resources;

namespace dihiddieDiary.Models.Diary
{
    public sealed class PostViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(SharedResources.Title), ResourceType = typeof(SharedResources))]
        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public DateTime CreateDateTime { get; set; }

        // public string ImagePreviewPath { get; set; }

        public string PreviewContent { get; set; }

        // lic bool IsPreviewed { get; set; }
    }
}