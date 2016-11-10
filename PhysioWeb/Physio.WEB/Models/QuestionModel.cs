using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioQA.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public int PatientId { get; set; }
        public string QuestionText { get; set; }
        public int AnswerVal { get; set; }
    }
}