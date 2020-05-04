
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniErp.Application.Data;
using MiniErp.Application.Helpers;
using MiniErp.Application.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Tests
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
            services.AddScoped<MySqlContext>();
            services.Configure<AppConnectionSettings>(options => Configuration.GetSection(AppSettings.MySqlConnection).Bind(options));
        }
    }



}
