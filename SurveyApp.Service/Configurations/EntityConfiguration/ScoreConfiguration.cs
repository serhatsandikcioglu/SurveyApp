using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyApp.Data.Entities;

namespace SurveyApp.Service.Configurations.EntityConfiguration
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Score");
            builder.Property(x => x.SurveyId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.NumberOfCorrectAnswer).IsRequired();
                
            builder.HasOne(c => c.Survey).WithMany().HasForeignKey(c => c.SurveyId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
