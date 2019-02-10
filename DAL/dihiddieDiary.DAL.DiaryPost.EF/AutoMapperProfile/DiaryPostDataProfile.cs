using AutoMapper;

namespace dihiddieDiary.DAL.DiaryPost.EF.AutoMapperProfile
{
    public sealed class DiaryPostDataProfile : Profile
    {
        public DiaryPostDataProfile()
        {
            CreateMap<diary_post, Core.Models.DiaryPost>();
            CreateMap<Core.Models.DiaryPost, diary_post>();
        }
    }
}
