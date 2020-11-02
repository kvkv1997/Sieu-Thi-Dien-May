
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Model2;
using PagedList;

namespace Model2.DAO
{
    public class ProductDao
    {
        public static void Insert(Product model
           )
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                var key = db.Products.FirstOrDefault(m => m.MaSp == model.MaSp);
                if (key!= null)
               
                     throw new Exception("Mã sản phẩm đã tồn tại");
                
                else
                {
                    db.Products.Add(model);
                    db.SaveChanges();
                }
               
            }
        }
        public static void Delete(int id)
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                var pro = db.Products.FirstOrDefault(l => l.ID_Product.Equals(id));
                if (pro == null) throw new Exception("Mã sản phẩm không tồn tại");
                db.Products.Remove(pro);
                db.SaveChanges();
            }
        }



        public static void Update(Product model)
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                var pro = db.Products.FirstOrDefault(l => l.MaSp.Equals(model.MaSp));
                if (pro == null) throw new Exception("Mã sản phẩm không tồn tại");
                pro.MaSp = model.MaSp;
                pro.TenSP = model.TenSP;
                pro.Mota = model.Mota;
                pro.GiaBan = model.GiaBan;
                pro.GiaKM = model.GiaKM;
                pro.Quantity = model.Quantity;
                pro.ID_Bill = model.ID_Bill;
                pro.NhaCungCap = model.NhaCungCap;
                db.SaveChanges();
            }
        }

        public  IEnumerable<Product> GetAll(int page, int pageSize)
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                return db.Products.OrderByDescending(x=>x.MaSp).ToPagedList(page, pageSize);
            }
        }

        public static  Product getByID(int id)
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                return db.Products.SingleOrDefault(t => t.ID_Product == id);
            }
        }
    }
}
