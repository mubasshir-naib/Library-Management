using LibraryManagement.Core.Interfaces;

namespace LibraryManagement.Api.Services
{
    public class AppEnvironment : IAppEnvironment
    {
        private readonly IWebHostEnvironment _env;

        public AppEnvironment(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string WebRootPath => _env.WebRootPath;
        public string ContentRootPath => _env.ContentRootPath;
    }
}
