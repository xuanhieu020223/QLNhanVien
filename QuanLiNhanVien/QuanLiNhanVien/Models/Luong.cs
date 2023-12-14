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
    
    public partial class Luong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Luong()
        {
            this.BaoHiems = new HashSet<BaoHiem>();
            this.ChamCongs = new HashSet<ChamCong>();
            this.KhenThuongs = new HashSet<KhenThuong>();
            this.KyLuats = new HashSet<KyLuat>();
            this.PhuCapNVs = new HashSet<PhuCapNV>();
            this.TangCas = new HashSet<TangCa>();
            this.UngLuongs = new HashSet<UngLuong>();
        }
    
        public int MaNV { get; set; }
        public string ViTri { get; set; }
        public Nullable<double> LươngCB { get; set; }
        public Nullable<double> PhuCap { get; set; }
        public Nullable<double> Thuong { get; set; }
        public Nullable<double> KhauTru { get; set; }
        public Nullable<double> BaoHiem { get; set; }
        public Nullable<double> TongTien { get; set; }
        public Nullable<System.DateTime> Day { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoHiem> BaoHiems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhenThuong> KhenThuongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyLuat> KyLuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuCapNV> PhuCapNVs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TangCa> TangCas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UngLuong> UngLuongs { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
