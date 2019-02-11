using dihiddieDiary.DAL.DiaryPost.EF.Repository;
using System;
using dihiddieDiary.DAL.DiaryPost.Core.Interfaces;

namespace dihiddieDiary.DAL.DiaryPost.EF.UnitOfWork
{
    public sealed class DiaryUnitOfWork : IDisposable, IDiaryUnitOfWork
    {
        private readonly DihiddieDiaryEntities context;

        public DiaryUnitOfWork()
        {
            context = new DihiddieDiaryEntities();
            InitRepositories();
        }

        public IDiaryRepository DiaryRepository { get; set; }

        private void InitRepositories() => DiaryRepository = new DiaryRepository(context);

        public void Dispose() => context?.Dispose();

        public void SaveChanges() => context.SaveChanges();
    }
}
