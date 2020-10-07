using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IItemGroupRepository, ItemGroupRepository>();
            services.AddTransient<IItemGroupBusiness, ItemGroupBusiness>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
            services.AddTransient<ILoaispRepository, LoaispRepository>();
            services.AddTransient<ILoaispBusiness, LoaispBusiness>();
            services.AddTransient<ISanphamRepository, SanphamRepository>();
            services.AddTransient<ISanphamBusiness, SanphamBusiness>();
            services.AddTransient<INccRepository, NccRepository>();
            services.AddTransient<INccBusiness, NccBusiness>();
            services.AddTransient<IGiamgiaRepository, GiamgiaRepository>();
            services.AddTransient<IGiamgiaBusiness, GiamgiaBusiness>();
            services.AddTransient<IThanhvienRepository, ThanhvienRepository>();
            services.AddTransient<IThanhvienBusiness, ThanhvienBusiness>();
            services.AddTransient<ITintucRepository, TintucRepository>();
            services.AddTransient<ITintucBusiness, TintucBusiness>();
            services.AddTransient<IThongkeRepository, ThongkeRepository>();
            services.AddTransient<IThongkeBusiness, ThongkeBusiness>();
            services.AddTransient<INhomtinRepository, NhomtinRepository>();
            services.AddTransient<INhomtinBusiness, NhomtinBusiness>();
            services.AddTransient<IHoadonnhapRepository, HoadonnhapRepository>();
            services.AddTransient<IHoadonnhapBusiness, HoadonnhapBusiness>();
            services.AddTransient<IHoadonbanRepository, HoadonbanRepository>();
            services.AddTransient<IHoadonbanBusiness, HoadonbanBusiness>();
            services.AddTransient<IDonhangRepository, DonhangRepository>();
            services.AddTransient<IDonhangBusiness, DonhangBusiness>();
            services.AddTransient<IChitietHDNRepository, ChitietHDNRepository>();
            services.AddTransient<IChitietHDNBusiness, ChitietHDNBusiness>();
            services.AddTransient<IChitietHDBRepository, ChitietHDBRepository>();
            services.AddTransient<IChitietHDBBusiness, ChitietHDBBusiness>();
            services.AddTransient<IChitietDHRepository, ChitietDHRepository>();
            services.AddTransient<IChitietDHBusiness, ChitietDHBusiness>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemBusiness, ItemBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiMiddleware();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection(); 
        }
    }
}
