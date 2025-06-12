using Microsoft.Extensions.Configuration;

namespace SimpleAdminPanel
{
    public class ApiURLRouter
    {
        private IConfiguration _configuration;

        public ApiURLRouter(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string GetListApiUrl()
        {
            return _configuration.GetValue<string>("GetListApiUrl");
        }

        public string CreateApiUrl()
        {
            return _configuration.GetValue<string>("CreateApirUrl");
        }
    }
}
