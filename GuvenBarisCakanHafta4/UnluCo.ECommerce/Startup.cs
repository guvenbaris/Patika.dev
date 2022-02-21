using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UnluCo.ECommerce.Authentication;
using UnluCo.ECommerce.DataAccess;
using UnluCo.ECommerce.Extensions;
using UnluCo.ECommerce.Services;
using UnluCo.ECommerce.Services.Business;
using UnluCo.ECommerce.Authorization;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Filters;

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
            services.AddControllers(config=>
                config.Filters.Add(new HeaderFilter()
                ));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UnluCo.ECommerce", Version = "v1" });
            });

            //Service'lere yapýlan injectionlar eklenmiþtir. Böylece instancelarý oluþturulmuþtur.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IProductService, ProductManager>(); // Fake services olduðu için Transient eklenmiþtir. Örnek olmasý açýsýndan
            services.AddSingleton<ILoggerService, ConsoleLogger>();
            
            services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("default")));

            services.AddTransient<IProductRepository, ProductRepository>();


            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.User.AllowedUserNameCharacters =
                    "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+";
            }).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders();


            services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
                }
            );

            services.AddScoped<TokenGenarator>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
            
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnluCo.ECommerce v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //Customer Middleware'larý tanýmladýðýmýz yer araya girmesini istediðimi kýsým.
            app.UseCustomLogMiddle(); // => Log middleware.

            //app.UseCustomeExceptionMiddle();// Exception middleware.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            CreateRoles(serviceProvider);
        }


        private void CreateRoles(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();

            string[] roleNames = { "Admin", "Manager", "Member" };


            foreach (var role in roleNames)
            {
                var roleExist = roleManager.RoleExistsAsync(role);
                if (!roleExist.Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            var powerUser = new AppUser
            {
                UserName = Configuration["AppSettings:UserName"],
                Email = Configuration["AppSettings:UserEmail"],
            };
            var userPassword = Configuration["Appsettings:UserPassword"];
            var user = userManager.FindByEmailAsync(Configuration["AppSettings:AdminUserEmail"]).Result;
            if (user is null)
            {
                var createPowerUser = userManager.CreateAsync(powerUser, userPassword).Result;
                if (createPowerUser.Succeeded)
                {
                    userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
    }

