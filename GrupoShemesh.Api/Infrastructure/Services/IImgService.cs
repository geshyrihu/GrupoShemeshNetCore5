using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GrupoShemesh.Infrastructure.Services
{
    public interface IImgService
    {
        string SaveFile(IFormFile file, string path, int width = 1296, int height = 972);
        Task DeleteFile(string path, string filename);
    }

    public class ImgService : IImgService
    {
        public string SaveFile(IFormFile file, string path, int width = 1296, int height = 972)
        {
            var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string finalPath = Path.Combine(path, filename);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(width, height));
            image.Save(finalPath);
            return filename;
        }
        public Task DeleteFile(string path, string filename)
        {
            string filePath = Path.Combine(path, filename);
            if (!File.Exists(filePath))
            {
                return Task.FromResult($"no existe el archivo {filename}");
            }
            else
            {
                File.Delete(filePath);
                return Task.FromResult($"Archivo {filename} eliminado");
            }
        }

    }
}
