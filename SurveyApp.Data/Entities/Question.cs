﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Entities
{
    public class Question : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public List<string> Choises { get; set; }
        public int CorrectChoiseIndex { get; set; }
    }
}
