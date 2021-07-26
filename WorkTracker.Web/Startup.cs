using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using WorkTracker.Business.Services.Implementations;
using WorkTracker.Business.Services.Interfaces;
using WorkTracker.Data.Infrastructure;
using WorkTracker.Data.Repository.Implementations;
using WorkTracker.Data.Repository.Interfaces;
using WorkTracker.Web.Models.Mappings;

namespace WorkTracker.Web
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
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<WorkDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DockerDbConnection")));

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IProjectService, ProjectService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkTracker.Web", Version = "v1" });

                var xmlFilePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

                c.IncludeXmlComments(xmlFilePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkTracker.Web v1"));
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
