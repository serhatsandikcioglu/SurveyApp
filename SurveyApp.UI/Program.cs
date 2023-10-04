using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.DataBase;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Data.Interfaces;
using SurveyApp.Data.Repositories;
using SurveyApp.Service.Configurations;
using SurveyApp.Service.Interfaces;
using SurveyApp.Service.Mapper;
using SurveyApp.Service.Services;
using SurveyApp.Service.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
ServiceConfiguration.ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!dbContext.Roles.Any())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AspNetRole>>();
        await roleManager.CreateAsync(new() { Name = "Admin" });
        await roleManager.CreateAsync(new() { Name = "User" });
    }
    if (!dbContext.Users.Any())
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AspNetUser>>();
        var user = new AspNetUser() { UserName = "admin" , Name="AdminName" , Surname="AdminSurname" , Email="admin@admin.com"};
        await userManager.CreateAsync(user, "Asd123**");
        await userManager.AddToRoleAsync(user, "admin");

    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{ 
endpoints.MapAreaControllerRoute(
    name:"Admin",
    areaName:"Admin",
    pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
