using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using AutoMapper;
using dihiddieDiary.DAL.DiaryPost.Core.Interfaces;

namespace dihiddieDiary.DAL.DiaryPost.EF.Repository
{
    public sealed class DiaryRepository : IDiaryRepository
    {
        private readonly DihiddieDiaryEntities context;

        private readonly int previewSymbolsCount;

        public DiaryRepository(DihiddieDiaryEntities entities)
        {
            context = entities;
            previewSymbolsCount = int.Parse(ConfigurationManager.AppSettings["PreviewSymbolsCount"]);
        }

        public void SavePost(Core.Models.DiaryPost post)
        {
            context.diary_post.Add(Mapper.Map<diary_post>(post));
        }

        public Core.Models.DiaryPost[] GetPreviews(int take, int skip)
        {
            List<Core.Models.DiaryPost> diaryPosts = new List<Core.Models.DiaryPost>();
            var posts = context.diary_post.OrderByDescending(x => x.createDateTime).ToList(); //Take(take).Skip(skip);
            foreach (var post in posts)
            {
                var diaryPost = Mapper.Map<Core.Models.DiaryPost>(post);
                diaryPost.PreviewContent = GetContentForPreview(Encoding.UTF8.GetString(post.content));
                diaryPosts.Add(diaryPost);
            }

            return diaryPosts.ToArray();
        }

        public Core.Models.DiaryPost GetPost(int postId)
        {
            return null;
        }

        private string GetContentForPreview(string content)
        {
            if (content.Length <= previewSymbolsCount) return content;
            var onSymbolsCount = content.Substring(previewSymbolsCount);
            var closedTagIndexOf = onSymbolsCount.IndexOf(">", StringComparison.Ordinal);
            return content.Substring(0, previewSymbolsCount + closedTagIndexOf);
        }
    }
}
