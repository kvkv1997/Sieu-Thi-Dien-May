namespace Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTV")]
    public partial class LoaiTV
    {
        [Key]
        [StringLength(50)]
        public string Type_Emp { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Detail { get; set; }
    }
}
