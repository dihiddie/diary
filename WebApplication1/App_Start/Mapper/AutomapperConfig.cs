using System.Reflection;
using dihiddieDiary.DAL.DiaryPost.EF.AutoMapperProfile;

namespace dihiddieDiary.Mapper
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.AddProfiles(Assembly.GetExecutingAssembly());
                c.AddProfile<DiaryPostDataProfile>();
                c.AddProfile<DiaryPostViewModelDataProfile>();
            });
        }
    }
}