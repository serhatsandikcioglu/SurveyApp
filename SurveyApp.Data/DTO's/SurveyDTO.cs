﻿using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.DTO_s
{
    public class SurveyDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid Id { get; set; }
        public List<Guid> QuestionsId { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public List<int> CorrectAnswerIndexes { get; set; }
        public Guid? AppUserId { get; set; }
        public AspNetUser? AppUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
