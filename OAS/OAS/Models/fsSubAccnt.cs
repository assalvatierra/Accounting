//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OAS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fsSubAccnt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fsSubAccnt()
        {
            this.fsTrxDetails = new HashSet<fsTrxDetail>();
        }
    
        public int Id { get; set; }
        public int fsAccountId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int fsEntityId { get; set; }
    
        public virtual fsAccount fsAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fsTrxDetail> fsTrxDetails { get; set; }
        public virtual fsEntity fsEntity { get; set; }
    }
}
