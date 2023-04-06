using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Repositories.Abstract;
using MongoDB_WebAPI.Repositories.Concrete;
using MongoDB_WebAPI.Service.Abstract;
using MongoDB_WebAPI.Service.Concrete;
using MongoDB_WebAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_WebAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoDB_WebAPI", Version = "v1" });
            });

            /* appsettings.json konfigürasyon dosyamýzýn içerisinde ki, MongoDbSettings isminde ki section'ýn alýnacaðýný ve bunun MongoDbSettings sýnýfýnýn property'leriyle set edileceðini belirtiyoruz. */
            services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));

            /* DI için gerekli olan, Controller'larýn contractor'larýnda IDbSettings interface'inin taþýyabileceði instance'larýn,çözümlenerek enjekte edilebileceðini belirtiyoruz. */
            services.AddSingleton<IDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            ////////////////////////////////////////
            services.AddSingleton<IGenericRepository<User>, UserRepository>();
            services.AddSingleton<IGenericRepository<Product>, ProductRepository>();
            services.AddSingleton<IGenericRepository<Category>, CategoryRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ICategoryService, CategoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoDB_WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
