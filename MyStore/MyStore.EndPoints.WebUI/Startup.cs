using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyStore.Core.Contracts.Categories;
using MyStore.Core.Contracts.Products;
using MyStore.Infrastructures.Dal.Categories;
using MyStore.Infrastructures.Dal.Commons;
using MyStore.Infrastructures.Dal.Products;

namespace MyStore.EndPoints.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            services.AddDbContext<MyStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("storeDb")));
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            //app.UseMvc();     
            // Replace UseMvc or UseSignalR with UseEndpoints.

            /* endpoint routing in core 3:
                1. determine route => UseRouting()
                2. execute route => UseEndpoints()*/





            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "CategoryWithPage",
                    pattern: "{category}/Page{pageNumber:int}",
                    defaults: new { controller = "Product", action = "List" }
                );

                endpoints.MapControllerRoute(
                    name: "ProductPaging",
                    pattern: "Page{pageNumber:int}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                    }
                );

                endpoints.MapControllerRoute(
                    name: "Category",
                    pattern: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=product}/{action=list}/{id?}"
                );


                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
