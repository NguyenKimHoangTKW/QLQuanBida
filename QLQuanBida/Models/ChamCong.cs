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
    
    public partial class ChamCong
    {
        public int idChamCong { get; set; }
        public System.DateTime NgayLam { get; set; }
        public System.DateTime VaoLam { get; set; }
        public System.DateTime TanLam { get; set; }
        public int idNV { get; set; }
        public string CaLam { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}