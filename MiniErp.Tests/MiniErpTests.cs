using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniErp.Application.Data;
using MiniErp.Application.Data.MySql.Repositories;
using MiniErp.Application.Helpers;
using MiniErp.Application.Services.v1;
using MiniErp.Application.Settings;
using Moq;

namespace MiniErp.Tests
{
    public class MiniErpTests: Startup
    {
        protected PartnerService Service;
        public MiniErpTests()
        {
            
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<PartnerRepository>();
            services.AddTransient<PartnerService>();
            services.AddScoped<MySqlContext>();
            services.Configure<AppConnectionSettings>(options => Configuration.GetSection(AppSettings.MySqlConnection).Bind(options));

            var serviceProvider = services.BuildServiceProvider();
            Service = (PartnerService)serviceProvider.GetService(typeof(PartnerService));
        }

    }
}
