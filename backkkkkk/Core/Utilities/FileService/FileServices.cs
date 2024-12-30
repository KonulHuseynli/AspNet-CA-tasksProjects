using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "assets2/images", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public void Delete(string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "assets2/images", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public bool IsImage(IFormFile file)
        {
            if (file.ContentType.Contains("image/"))
            {
                return true;
            }

            return false;
        }

        public bool CheckSize(IFormFile file, int size)
        {
            if (file.Length / 1024 > size)
            {
                return false;
            }
            return true;
        }


        public string ReadFile(string path, string template)
        {

            using (StreamReader reader = new StreamReader(path))
            {
                template = reader.ReadToEnd();
            }
            return template;
        }
    }
}