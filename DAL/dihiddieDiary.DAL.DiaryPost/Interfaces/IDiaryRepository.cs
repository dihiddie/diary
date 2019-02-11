namespace dihiddieDiary.DAL.DiaryPost.Core.Interfaces
{
    public interface IDiaryRepository
    {
        void SavePost(Models.DiaryPost post);

        Models.DiaryPost[] GetPreviews(int take, int skip);

        Models.DiaryPost GetPost(int postId);
    }
}
