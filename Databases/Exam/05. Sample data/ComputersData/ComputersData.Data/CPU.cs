//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputersData.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CPU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPU()
        {
            this.Computers = new HashSet<Computer>();
        }
    
        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public int NumberOfCores { get; set; }
        public string ClockCycles { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Computer> Computers { get; set; }
    }
}