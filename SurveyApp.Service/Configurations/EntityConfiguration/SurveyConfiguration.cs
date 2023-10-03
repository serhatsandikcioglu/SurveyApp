using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Configurations.EntityConfiguration
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Survey");
            builder.Property(x => x.QuestionsId).IsRequired();
            builder.Property(x => x.CorrectAnswerIndexes).IsRequired();

            builder.HasOne(c => c.Questions).WithMany().HasForeignKey(c => c.QuestionsId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
