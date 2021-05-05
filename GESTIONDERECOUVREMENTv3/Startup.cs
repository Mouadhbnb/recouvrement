using GESTIONDERECOUVREMENT.Helper;
using GESTIONDERECOUVREMENT.Models;
//using GESTIONDERECOUVREMENT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTIONDERECOUVREMENT
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
           services.AddDbContext<dataRECOUVREMENTContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GESTIONDERECOUVREMENT")));
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(x =>
            {

                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "KPI API", Version = "v1" });

            });



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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option =>

            {

                option.RouteTemplate = swaggerOptions.JsonRoute;

            });

            app.UseSwaggerUI(option =>

            {

                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);

            });
        }
    }
}
