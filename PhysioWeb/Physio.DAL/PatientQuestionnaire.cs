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
    
    public partial class PatientQuestionnaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientQuestionnaire()
        {
            this.PatientAnswers = new HashSet<PatientAnswer>();
        }
    
        public int Id { get; set; }
        public int QuestionSetId { get; set; }
        public int PatientId { get; set; }
        public System.DateTime QuestionnaireDate { get; set; }
    
        public virtual Patient Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientAnswer> PatientAnswers { get; set; }
        public virtual QuestionSet QuestionSet { get; set; }
    }
}
