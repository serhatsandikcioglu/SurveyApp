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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Choices).IsRequired();
            builder.Property(x => x.IsConfirmed).IsRequired();

        }
    }
}
