namespace Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            CTPNs = new HashSet<CTPN>();
            CTPXes = new HashSet<CTPX>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        [Key]
        public long ID_Product { get; set; }

        [StringLength(250)]
        public string TenSP { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        public decimal? GiaKM { get; set; }

        public decimal? GiaBan { get; set; }

        public long? ID_Bill { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string NhaCungCap { get; set; }

        public decimal? GiaNhap { get; set; }

        [StringLength(50)]
        public string MaSp { get; set; }
      //  public Boolean Status { get; set; } = true;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPX> CTPXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
