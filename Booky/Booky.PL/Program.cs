using Booky.BL.Interfaces;
using Booky.BL.Repositories;
using Booky.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Booky.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Application Services Withing DI
            // Add services to the container.
            builder.Services.AddControllersWithViews(); 
            builder.Services.AddDbContext<BookyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion
            builder.Services.AddScoped(typeof(Iunitofwork), typeof(UnitofWork)); //lifetime period 

            //addscope
            //addsingleton
            //Addtransient //it will create object per operation 
            //            builder.Services.AddSingleton(typeof(Iunitofwork), typeof(UnitofWork)); it will create an object it will exist until the application is closed 
            //           builder.Services.AddScoped(typeof(Iunitofwork), typeof(UnitofWork)) it will create an object per request
            var app = builder.Build();

            #region Application Request  Piplines
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); 
            #endregion

            app.Run();
        }
    }
}