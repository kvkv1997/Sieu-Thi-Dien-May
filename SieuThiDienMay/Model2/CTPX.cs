namespace Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPX")]
    public partial class CTPX
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_Product { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_PhieuXuat { get; set; }

        [StringLength(10)]
        public string SoLuong { get; set; }

        [StringLength(10)]
        public string GiaXuat { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }

        public virtual Product Product { get; set; }
    }
}
