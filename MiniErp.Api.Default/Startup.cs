using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniErp.Application.Data;
using MiniErp.Application.Data.MySql.Repositories;
using MiniErp.Application.Helpers;
using MiniErp.Application.Services.v1;
using MiniErp.Application.Settings;


namespace MiniErp.Api.Default
{
    public class Startup : StartupBase
    {

        public Startup()
        {

        }


        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        public override void BeforeConfigureServices(IServiceCollection services)
        {
            base.BeforeConfigureServices(services);
            services.AddScoped<PartnerService>();
            services.AddScoped<PartnerRepository>();
            services.AddScoped<MySqlContext>();
            services.Configure<AppConnectionSettings>(options => Configuration.GetSection(AppSettings.MySqlConnection).Bind(options));
        }

    }
}
