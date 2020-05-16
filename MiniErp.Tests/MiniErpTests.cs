using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniErp.Application.Data;
using MiniErp.Application.Data.MySql.Repositories;
using MiniErp.Application.Services.v1;
using MiniErp.Application.Settings;

namespace MiniErp.Tests
{
    public class MiniErpTests: Startup
    {
        protected PartnerService Service;
        protected PartnerRepository Repository;
        public MiniErpTests()
        {
            
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<PartnerRepository>();
            services.AddTransient<PartnerService>();
            services.AddScoped<MySqlContext>();
            services.Configure<AppConnectionSettings>(options => Configuration.GetSection(AppSettings.MySqlConnection).Bind(options));

            var serviceProvider = services.BuildServiceProvider();
            Service = (PartnerService)serviceProvider.GetService(typeof(PartnerService));
            Repository = (PartnerRepository)serviceProvider.GetService(typeof(PartnerRepository));
        }

    }
}
