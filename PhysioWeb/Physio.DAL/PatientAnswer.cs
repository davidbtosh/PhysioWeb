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
    
    public partial class PatientAnswer
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionnaireId { get; set; }
        public string Answer { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual PatientQuestionnaire PatientQuestionnaire { get; set; }
        public virtual Question Question { get; set; }
    }
}