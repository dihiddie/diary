using AutoMapper;
using dihiddieDiary.DAL.DiaryPost.Core.Interfaces;
using System.Configuration;
using System.Linq;

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
            var posts = context.diary_post.OrderByDescending(x => x.createDateTime).ToList(); //Take(take).Skip(skip);
            return Mapper.Map<Core.Models.DiaryPost[]>(posts);
        }

        public Core.Models.DiaryPost GetPost(int postId)
        {
            var postInDb = context.diary_post.FirstOrDefault(x => x.id == postId);
            return Mapper.Map<Core.Models.DiaryPost>(postInDb);
        }
    }
}
