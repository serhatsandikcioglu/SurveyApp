using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.DataBase
{
    public class AppDbContext : IdentityDbContext<AspNetUser, AspNetRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            SeedDatabase(modelBuilder);
        }
        protected void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = Guid.NewGuid(),
                    Text = "En sevdiği yemek?",
                    Choices = new List<string> { "Patates Kızartması", "Burger", "Döner", "Kuru Fasulye", "Makarna" },
                    IsConfirmed = true
                }, new Question
                {
                    Id = Guid.NewGuid(),
                    Text = "En sevdiği müzik türü?",
                    Choices = new List<string> { "Pop", "Rap", "Rock", "Türk Halk Müziği", "Arabes" },
                    IsConfirmed = true
                }, new Question
                {
                    Id = Guid.NewGuid(),
                    Text = "Zamanını nasıl geçirir?",
                    Choices = new List<string> { "Uyuyarak", "Bilgisayar başında", "Yürüyüş yaparak", "Kitap okuyarak", "Arkadaşlarıyla buluşarak" },
                    IsConfirmed = true
                }, new Question
                {
                    Id = Guid.NewGuid(),
                    Text = "Onu en çok ne sevindirir?",
                    Choices = new List<string> { "Kayıp parayı bulmak", "Tuttuğu takımın galibiyeti", "Süpriz hediye almak", "Alışveriş mağazasındaki indirimler", "Çekilişle telefon kazanmak" },
                    IsConfirmed = true
                }
            );
        }
    }
}
