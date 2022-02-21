using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UnluCo.ECommerce.Extensions;
using UnluCo.ECommerce.Services;
using UnluCo.ECommerce.Services.Business;

namespace UnluCo.ECommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UnluCo.ECommerce", Version = "v1" });
            });
            //Service'lere yapýlan injectionlar eklenmiþtir. Böylece instancelarý oluþturulmuþtur.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IProductService, ProductManager>(); // Fake services olduðu için Transient eklenmiþtir. Örnek olmasý açýsýndan
            services.AddSingleton<ILoggerService, ConsoleLogger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnluCo.ECommerce v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            //Customer Middleware'larý tanýmladýðýmýz yer araya girmesini istediðimi kýsým.
            app.UseCustomLogMiddle(); // => Log middleware.

            app.UseCustomeExceptionMiddle();// Exception middleware.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
