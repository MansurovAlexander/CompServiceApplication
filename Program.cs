using CompServiceApplication.Interfaces;
using CompServiceApplication.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace CompServiceApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews().AddRazorOptions(options =>
            {
                options.ViewLocationFormats.Add("/{0}.cshtml");
            });

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<IInWorkRepository, InWorkRepository>();
            builder.Services.AddScoped<IPartToDeviceRepository, PartToDeviceRepository>();
            builder.Services.AddScoped<IPartToOrderRepository, PartToOrderRepository>();
            builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            builder.Services.AddScoped<IRepairInWorkRepository, RepairInWorkRepository>();
            builder.Services.AddScoped<IRepairTypeRepository, RepairTypeRepository>();
            builder.Services.AddScoped<ITaskOrderRepository, TaskOrderRepository>();
            builder.Services.AddScoped<IUsedPartRepository, UsedPartRepository>();
            builder.Services.AddScoped<IUserInWorkRepository, UserInWorkRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            builder.Services.AddScoped<IVisualFlowRepository, VisualFlowRepository>();
            builder.Services.AddScoped<IWareHouseRepository, WareHouseRepository>();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Authorization}/{action=Index}/{id?}");

			app.Run();
        }
    }
}