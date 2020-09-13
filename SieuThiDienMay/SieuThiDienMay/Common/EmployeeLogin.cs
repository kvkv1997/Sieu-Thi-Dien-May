using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SieuThiDienMay.Common
{
    [Serializable]
    public class EmployeeLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }

    }
}