namespace dihiddieDiary.DAL.DiaryPost.Core.Interfaces
{
    public interface IDiaryUnitOfWork
    {
        IDiaryRepository DiaryRepository { get; set; }
    }
}
