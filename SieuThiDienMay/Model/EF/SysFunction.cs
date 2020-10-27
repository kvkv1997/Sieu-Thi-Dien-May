using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("SysFunction")]
  public  class SysFunction
    {
        [Key]
        [StringLength(50)]
        public string FunctionID { get; set; }
        [StringLength(50)]
        public string FunctionName { get; set; }
       
    }
}
