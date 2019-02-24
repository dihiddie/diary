using System;
using System.Configuration;
using AutoMapper;
using System.Text;

namespace dihiddieDiary.DAL.DiaryPost.EF.AutoMapperProfile
{
    public sealed class DiaryPostDataProfile : Profile
    {
        public DiaryPostDataProfile()
        {
            CreateMap<Core.Models.DiaryPost, diary_post>();

            CreateMap<diary_post, Core.Models.DiaryPost>()
           .ForMember(x => x.Id, x => x.MapFrom(y => y.id))
           .ForMember(x => x.Title, x => x.MapFrom(y => y.title))
           .ForMember(x => x.Content, x => x.MapFrom(y => y.content))
           .ForMember(x => x.PreviewContent, x => x.MapFrom(y => GetContentForPreview(Encoding.UTF8.GetString(y.content))))
           .ForMember(x => x.CreateDateTime, x => x.MapFrom(y => y.createDateTime))
           .ForMember(x => x.UpdateDateTime, x => x.MapFrom(y => y.updateDateTime));
        }

        private string GetContentForPreview(string content)
        {
            var previewSymbolsCount = int.Parse(ConfigurationManager.AppSettings["PreviewSymbolsCount"]);
            if (content.Length <= previewSymbolsCount) return content;
            var onSymbolsCount = content.Substring(0, previewSymbolsCount);
            var closedTagIndexOf = onSymbolsCount.IndexOf(">", StringComparison.Ordinal);
            return content.Substring(0, previewSymbolsCount + closedTagIndexOf);
        }
    }
}
