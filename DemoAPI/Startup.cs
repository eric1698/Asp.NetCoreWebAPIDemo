using AutoMapper;
using BLL;
using BLL.interfaces;
using DAL;
using DemoAPI.Filter;
using FluentValidation.AspNetCore;
using IDAL;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.ViewModels.Mappings;
using Model.ViewModels.Validations;
using System.IO;

namespace DemoAPI
{
    public class Startup
    {
        public static ILoggerRepository repository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            repository = LogManager.CreateRepository("Log4netRepository");
            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        public IConfiguration Configuration { get; }
        readonly string myCors = "myCors";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<DemoDbContext, DemoDbContext>();
            services.AddScoped<IContentBLL, ContentBLL>();

            services.AddAutoMapper(typeof(ViewModelToEntityMappingProfile));

            services.AddMvc( opt => {
                opt.Filters.Add(typeof(ValidationFilter));
                opt.Filters.Add(typeof(GlobalExceptionFilter)); })
                .AddJsonOptions(opt => opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss")
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ContentCreateValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options => options.AddPolicy(myCors, builder => builder.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod()));
            services.AddDbContext<DemoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connStr")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(myCors);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
