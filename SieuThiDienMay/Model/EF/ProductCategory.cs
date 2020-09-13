namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            Categories = new HashSet<Category>();
        }

        [Key]
        public long ID_ProductCategory { get; set; }

        public long? ID_Product { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string MetaTiltle { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        public bool? ShoworHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        public virtual Product Product { get; set; }
    }
}
