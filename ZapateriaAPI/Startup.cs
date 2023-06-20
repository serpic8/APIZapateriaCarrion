using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using ZapateriaAPI.DbContexts;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using ZapateriaAPI.Repository.IRepository;
using ZapateriaAPI.Repository;

namespace ZapateriaAPI
{
    public class Startup
    {
        public static WebApplication RunApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {

            //builder.Services.AddDbContext<DataContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddAutoMapper(typeof(Startup));
            builder.Services.AddControllers().AddNewtonsoftJson();




            // Add authorization services
            builder.Services.AddAuthorization();

            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IInventaryRepository, InventaryRepository>();
            builder.Services.AddScoped<ISalesRepository, SalesRepository>();


            builder.Services.AddControllers();            


        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();   

            app.Run();
        }
    }
}
