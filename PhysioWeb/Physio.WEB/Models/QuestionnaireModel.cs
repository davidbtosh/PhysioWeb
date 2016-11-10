using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioQA.Models
{
    public class QuestionnaireModel
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }
        
        public int PatientQuestionnaireId { get; set; }

        public DateTime QuestionnaireDate { get; set; }

        public int QuestionSetId { get; set; }

        public string QuestionSetName { get; set; }
        
        public int QuestionId { get; set; }
        
        public string QuestionText { get; set; }
        
        public string QuestionHint { get; set; }
        
        public string UIcaption { get; set; }

        public string Answer { get; set; }

        public string QuestionAbbreviation { get; set; }
    }
}