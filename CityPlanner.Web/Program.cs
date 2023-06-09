using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace CityPlanner.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddScoped<GptService>();

            builder.Services.AddHostedService<PopulateDbHostedService>();

            builder.Services.AddDbContextFactory<DataContext>(options =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("MainDB"), ServerVersion.Create(new Version("5.6.42"), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql), options =>
                {
                    options.CommandTimeout(3600);
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}