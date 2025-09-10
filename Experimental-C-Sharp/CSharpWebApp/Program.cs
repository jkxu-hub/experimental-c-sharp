using CSharpWebApp.Controllers;
using CSharpWebApp.Hubs;
using Microsoft.AspNetCore.SignalR;
namespace CSharpWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<ChatRegistry>();
            builder.Services.AddSingleton<IUserIdProvider, UserIdProvider>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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

            app.MapHub<ChatHub>("/chatHub");
            app.MapHub<CustomHub>("/custom");
            app.MapHub<GroupsHub>("/groups");
            app.MapHub<AdvancedChatHub>("/advancedChat");

            app.Run();
        }
    }
}
