//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLQuanBida.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CKKM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CKKM()
        {
            this.KhachHangs = new HashSet<KhachHang>();
        }
    
        public int idCKKM { get; set; }
        public string MaCKKM { get; set; }
        public Nullable<double> TuGiaTri { get; set; }
        public Nullable<double> DenGiaTri { get; set; }
        public Nullable<int> MucCK { get; set; }
        public string MoTa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
