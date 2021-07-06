using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using CRUD_ASP_API.Services;
using CRUD_ASP_API.Services.Interfaces;
using CRUD_DAL;
using CRUD_DAL.DbConfiguration;
using CRUD_DAL.InsightDB;
using CRUD_DAL.Interfaces;
using CRUD_DAL.Repositories;
using CRUD_Logic.Services;
using LinqToDB.Mapping;
using Microsoft.AspNetCore.Rewrite;

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
            services.AddCors();
            services.AddControllers();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddScoped<IDbContext, DbContext>();
            services.AddSingleton<ConnectionStringSettings, ConnectionStringSettings>(x =>
                new ConnectionStringSettings("CRUD_DB", Configuration.GetConnectionString("Default"),
                    Configuration.GetConnectionString("ProviderName")));

            services.AddDatabase<CRUDDbConnection>(options
                => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<MappingSchema, CRUDMappingSchema>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());

            app.UseMiddleware<TestMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}