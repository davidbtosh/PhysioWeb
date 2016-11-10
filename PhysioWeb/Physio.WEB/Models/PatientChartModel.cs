using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioQA.Models
{
    public class PatientChartModel
    {
        public DateTime QuestionnaireDate { get; set; }

        public string QuestionAbbreviation { get; set; }

        public string Answer { get; set; }

        public int QuestionId { get; set; }

        public int PatientQuestionnaireId { get; set; }

    }
}