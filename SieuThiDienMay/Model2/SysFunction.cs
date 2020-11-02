namespace Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysFunction")]
    public partial class SysFunction
    {
        [Key]
        [StringLength(50)]
        public string FunctionID { get; set; }

        [StringLength(50)]
        public string FunctionName { get; set; }
    }
}
