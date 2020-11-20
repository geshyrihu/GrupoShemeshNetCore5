using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GrupoShemesh.Api.Helpers
{
    public interface IBaseUrl
    {
        string GetBaseUrl(string path);
    }

    public class BaseUrl : IBaseUrl
    {
        private readonly IWebHostEnvironment _env;

        public BaseUrl(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string GetBaseUrl(string path)
        {
            return Path.Combine(_env.WebRootPath, path);
        }


    }
}
