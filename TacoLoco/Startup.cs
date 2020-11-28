using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service.Integration.DataServices;
using Service.Integration.Models;
using Service.Integration.Profiles;
using Service.Integration.Services;
using TacoLoco.Extensions;
using TacoLoco.Filters;

namespace TacoLoco
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
            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddControllers();
            services.AddMvc(options => { options.Filters.Add<ValidationFilter>(); }
               ).AddFluentValidation(
                fv => fv.RegisterValidatorsFromAssemblyContaining<Customer>());

            
            services.AddScoped<IService, Service.Integration.Services.Service>();
            var connectionString = Configuration.GetConnectionString("MySQLConnection");

            services.AddDbContext<CustomerContext>(
                options => options.UseSqlServer(connectionString)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler();
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
