namespace Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPN")]
    public partial class CTPN
    {
        public long ID_Product { get; set; }

        public long ID_PhieuNhap { get; set; }
        public int? SoLuong { get; set; }

        public decimal? GiaNhap { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTietPN { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual Product Product { get; set; }
    }
}
