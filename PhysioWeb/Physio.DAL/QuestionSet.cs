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
    
    public partial class QuestionSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionSet()
        {
            this.PatientQuestionnaires = new HashSet<PatientQuestionnaire>();
            this.QuestionSetQuestions = new HashSet<QuestionSetQuestion>();
        }
    
        public int Id { get; set; }
        public string QuestionSetName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientQuestionnaire> PatientQuestionnaires { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionSetQuestion> QuestionSetQuestions { get; set; }
    }
}
