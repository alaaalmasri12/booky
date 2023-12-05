namespace Booky
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Application Services
            // Add services to the container.
            builder.Services.AddControllersWithViews();//Web MVC 
            #endregion

            var app = builder.Build();

            #region Application Request Piplines
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();//HTTP HTTPS
            app.UseStaticFiles();//css js Images

            app.UseRouting();//Routing Table 

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }
}