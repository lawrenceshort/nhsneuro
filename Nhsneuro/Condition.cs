//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhsneuro
{
    using System;
    using System.Collections.Generic;
    
    public partial class Condition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Condition()
        {
            this.ConditionSymptoms = new HashSet<ConditionSymptom>();
        }
    
        public int ConditionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsRare { get; set; }
        public Nullable<int> SnoMedId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConditionSymptom> ConditionSymptoms { get; set; }
    }
}
