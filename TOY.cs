//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestesAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class TOY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOY()
        {
            this.BOY_TOY = new HashSet<BOY_TOY>();
        }
    
        public int ID_TOY { get; set; }
        public string NM_TOY { get; set; }
        public int ID_TP_TOY { get; set; }
    
        public virtual TP_TOY TP_TOY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOY_TOY> BOY_TOY { get; set; }
    }
}
