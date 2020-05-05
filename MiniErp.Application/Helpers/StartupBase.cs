
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace MiniErp.Application.Helpers
{
    public abstract class StartupBase
    {

        protected StartupBase()
        {
            EnvLoader.LoadEnv();
        }


        public virtual void BeforeConfigureServices(IServiceCollection services)
        {
           
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {

            BeforeConfigureServices(services);
            services.AddApiVersioning();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
