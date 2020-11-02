using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2.DAO
{
    public class CTPNDao
    {
        SieuThiDienMayDbContext db = new SieuThiDienMayDbContext();
        public  void Add(CTPN model )
        {
            db.CTPNs.Add(model);
            db.SaveChanges();

        }
    }
}
