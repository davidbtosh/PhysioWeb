//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Physio.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwPatientQuestionnaire
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int QuestionSetId { get; set; }
        public int PatientQuestionnaireId { get; set; }
        public System.DateTime QuestionnaireDate { get; set; }
        public string QuestionSetName { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionAbbreviation { get; set; }
        public string QuestionHint { get; set; }
        public string UIcaption { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
    }
}
