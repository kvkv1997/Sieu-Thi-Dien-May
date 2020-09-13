namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public bool? ShoworHome { get; set; }

        public long? ID_PruductCategory { get; set; }

        [Key]
        public long ID_Category { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string MetaTiltle { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
