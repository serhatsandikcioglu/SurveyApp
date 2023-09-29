using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.DataBase;
using SurveyApp.Data.Interfaces;
using SurveyApp.Data.Repositories;
using SurveyApp.Service.Interfaces;
using SurveyApp.Service.Mapper;
using SurveyApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IQuestionRepository , QuestionRepository>();
builder.Services.AddScoped<IQuestionService , QuestionService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"), Action => {
        Action.MigrationsAssembly("SurveyApp.Data");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
