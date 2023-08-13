using Discount.Grpc.Repositories;
using Discount.Grpc.Services;
//using Discount.Grpc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc
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
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddAutoMapper(typeof(Startup));
            services.AddGrpc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DiscountService>();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("ds");
                });
            });
        }
    }
}