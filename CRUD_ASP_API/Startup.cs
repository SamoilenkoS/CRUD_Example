using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using CRUD_ASP_API.Services;
using CRUD_DAL;
using CRUD_DAL.DbConfiguration;
using CRUD_DAL.Interfaces;
using CRUD_DAL.Repositories;
using LinqToDB.Mapping;

namespace CRUD_ASP_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDatabase<CRUDDbConnection>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<MappingSchema, CRUDMappingSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
