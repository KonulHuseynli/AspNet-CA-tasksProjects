using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileService
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file);
        void Delete(string fileName);
        bool IsImage(IFormFile file);
        bool CheckSize(IFormFile file, int size);

        string ReadFile(string path, string template);
    }
}
