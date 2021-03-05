using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public interface IFileHelper
    {
        string Add(IFormFile file, string path);
        string Update(string pathToUpdate, IFormFile file, string path);
        void Delete(string path);
    }
}

