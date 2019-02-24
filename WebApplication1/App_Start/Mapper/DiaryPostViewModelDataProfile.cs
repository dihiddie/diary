using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using dihiddieDiary.DAL.DiaryPost.Core.Models;
using dihiddieDiary.Models.Diary;

namespace dihiddieDiary.Mapper
{
    public class DiaryPostViewModelDataProfile : Profile
    {
        private const string ImgSourceTagCaption = "src";
        private const string ImgDataFileName = "data-filename";
        private const string Base64TagCaption = "base64,";
        private const string slnCaption = "dihiddieDiary";

        public DiaryPostViewModelDataProfile()
        {
            CreateMap<PostViewModel, DiaryPost>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Title, x => x.MapFrom(y => y.Title))
                .ForMember(x => x.Content, x => x.MapFrom(y => GetBytesFromPost(y.Content)))
                .ForMember(x => x.CreateDateTime, x => x.MapFrom(y => y.CreateDateTime));

            CreateMap<DiaryPost, PostViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Title, x => x.MapFrom(y => y.Title))
                .ForMember(x => x.Content, x => x.MapFrom(y => Encoding.UTF8.GetString(y.Content)))
                .ForMember(x => x.CreateDateTime, x => x.MapFrom(y => y.CreateDateTime));
        }

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                var binDirectory = Path.GetDirectoryName(path);
                var applicationLevel = Path.GetFullPath(Path.Combine(binDirectory, @"..\"));
                return applicationLevel;
            }
        }

        private byte[] GetBytesFromPost(string content) => Encoding.UTF8.GetBytes(ParseImage(content));

        private string ParseImage(string content)
        {          
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

            MatchCollection imageMatches = Regex.Matches(content, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match imgMatch in imageMatches)
            {
                var reg = $"<img\\s+{ImgSourceTagCaption}=\"([^\"]+)\"\\s+{ImgDataFileName}=\"([^\"]+)\"";
                MatchCollection imageTagMatches = Regex.Matches(imgMatch.Value, reg, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (var match in imageTagMatches)
                {
                    var base64Source = ((Match) match).Groups[1];
                    var imgFileName = ((Match) match).Groups[2];
                    var savedFilePath = SaveImage(GetBase64FromSource(base64Source.Value), imgFileName.Value);
                    var processedImg = imgMatch.Value.Replace(base64Source.Value, savedFilePath);
                    content = content.Replace(imgMatch.Value, processedImg);
                }
            }      

            return content;
        }

        private string SaveImage(string imgBase64, string fileName)
        {
            var bytes = Convert.FromBase64String(imgBase64);
            var nestedPath = Path.Combine("Images", DateTime.Today.ToString("dd.MM.yyyy"));
            SaveImageToPath(bytes, nestedPath, fileName);
            return $"/{slnCaption}/{Path.Combine(nestedPath, fileName)}";
        }

        private void SaveImageToPath(byte[] imgBytes, string nestedPath, string fileName)
        {
            var directory = Path.Combine($"{AssemblyDirectory}", nestedPath);
            CreateIfNotExists(directory);
            var pathToSave = Path.Combine(directory, fileName);
            using (var imageFile = new FileStream(pathToSave, FileMode.Create))
            {
                imageFile.Write(imgBytes, 0, imgBytes.Length);
                imageFile.Flush();
            }
        }

        private string GetBase64FromSource(string content)
        {
            var startedIndex = content.IndexOf($"{Base64TagCaption}", StringComparison.Ordinal);
            return content.Substring(startedIndex + Base64TagCaption.Length);
        }    
        
        private void CreateIfNotExists(string filePath)
        {
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
        }       
    }
}
