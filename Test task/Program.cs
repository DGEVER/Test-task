using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_task.Models;

namespace Test_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conntectionString = builder.Configuration.GetConnectionString("DefaultString");

            // Add services to the container.

            builder.Services.AddControllers();


            builder.Services.AddDbContext<TestTaskContext>(options =>
            options.UseSqlServer(conntectionString));

            builder.Services.AddDbContext<TestTaskContext>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name:"default",
                pattern: "{controller}/{action}/{id?}"
                );

            app.Run();
        }
    }
}
