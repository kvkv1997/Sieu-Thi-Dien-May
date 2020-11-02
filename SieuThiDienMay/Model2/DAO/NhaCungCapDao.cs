using Model2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model2.DAO
{
   public class NhaCungCapDao
    {
        SieuThiDienMayDbContext db = null;
        public NhaCungCapDao()
        {
            db = new SieuThiDienMayDbContext();
        }
       public List<NhaCungCap> ListAll()
        {
            return db.NhaCungCaps.ToList();
        }
    }
}
