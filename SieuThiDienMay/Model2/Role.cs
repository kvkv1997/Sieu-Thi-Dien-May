namespace Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [Required]
        [StringLength(50)]
        public string FunctionID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type_Emp { get; set; }

        [StringLength(50)]
        public string RoleID { get; set; }
    }
}
