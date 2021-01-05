using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyExchange.DAL;
using MoneyExchange.DAL.Repository;
using MoneyExchange.DAL.Repository.Templates;
using MoneyExchange.Models;

namespace MoneyExchange
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
            services.AddScoped<IRepo<Exchange>, ExchangeRepo>();
            services.AddCors();
            services.AddControllers();

            // устанавливаем контекст данных
            string con = "Server=(localdb)\\mssqllocaldb;Database=MoneyExchange;Trusted_Connection=True;";
            services.AddDbContext<ExchangeContext>(options => options.UseSqlServer(con));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });


        }
    }
}
