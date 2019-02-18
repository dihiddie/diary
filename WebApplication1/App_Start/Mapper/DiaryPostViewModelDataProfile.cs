using System.Text;
using AutoMapper;
using dihiddieDiary.DAL.DiaryPost.Core.Models;
using dihiddieDiary.Models.Diary;

namespace dihiddieDiary.Mapper
{
    public class DiaryPostViewModelDataProfile : Profile
    {
        public DiaryPostViewModelDataProfile()
        {
            CreateMap<PostViewModel, DiaryPost>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Title, x => x.MapFrom(y => y.Title))
                .ForMember(x => x.Content, x => x.MapFrom(y => Encoding.UTF8.GetBytes(y.Content)))
                .ForMember(x => x.CreateDateTime, x => x.MapFrom(y => y.CreateDateTime));

            CreateMap<DiaryPost, PostViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Title, x => x.MapFrom(y => y.Title))
                .ForMember(x => x.Content, x => x.MapFrom(y => Encoding.UTF8.GetString(y.Content)))
                .ForMember(x => x.CreateDateTime, x => x.MapFrom(y => y.CreateDateTime));
        }
    }
}
