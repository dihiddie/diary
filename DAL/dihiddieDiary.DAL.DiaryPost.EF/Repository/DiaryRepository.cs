using dihiddieDiary.DAL.DiaryPost.Core.Interfaces;

namespace dihiddieDiary.DAL.DiaryPost.EF.Repository
{
    public sealed class DiaryRepository : IDiaryRepository
    {
        private readonly DihiddieDiaryEntities context;

        public DiaryRepository(DihiddieDiaryEntities entities) => context = entities;

        public void SavePost(Core.Models.DiaryPost post)
        {
        }
    }
}
