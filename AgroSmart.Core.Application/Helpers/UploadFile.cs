using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Helpers
{
    public static class UploadFile
    {
        //public static string UploadImage(IFormFile file, string directory, int id)
        //{

        //    string basePath = $"/Img/{directory}/{id}";
        //    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    Guid guid = Guid.NewGuid();
        //    FileInfo fileInfo = new FileInfo(file.FileName);
        //    string fileName = guid + fileInfo.Extension;
        //    string fileNameWithPath = Path.Combine(path, fileName);
        //    using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }
        //    return $"{basePath}/{fileName}";
        //}

        public static string UploadImage(IFormFile file, string directory,
           string id, bool isEditMode = false, string imageUrl = "")
        {
            if (isEditMode && file == null)
            {
                return imageUrl;
            }
            string basePath = $"/Images/{directory}/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = guid + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imageUrl.Split("/");
                string oldImage = oldImagePart[^1];
                string completePath = Path.Combine(basePath, oldImage);
                if (File.Exists(completePath))
                {
                    File.Delete(completePath);
                }
            }

            return $"{basePath}/{fileName}";
        }



        public static void RevomeImage(int id, string path)
        {
            string basePath = $"/Images/{path}/{id}";
            string pat = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(pat))
            {
                Directory.Delete(pat, true);
            }
        }
    }
}
