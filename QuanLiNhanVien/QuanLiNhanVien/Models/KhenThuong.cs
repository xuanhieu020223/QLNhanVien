//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLiNhanVien.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhenThuong
    {
        public int IDKT { get; set; }
        public string NameKT { get; set; }
        public int MaNV { get; set; }
        public Nullable<double> SoTien { get; set; }
        public string MoTa { get; set; }
    
        public virtual Luong Luong { get; set; }
    }
}