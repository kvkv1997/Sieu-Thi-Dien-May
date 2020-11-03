
using Model2;
using Model2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiDienMay.Areas.Admin.Controllers
{
    public class QuanLyPhieuNhapController : Controller
    {
        SieuThiDienMayDbContext db = new SieuThiDienMayDbContext();
        // GET: Admin/QuanLyPhieuNhap
        [HttpGet]
        public ActionResult NhapHang()
        {
            ViewBag.ID_NCC = db.NhaCungCaps;
            ViewBag.ListSanPham = db.Products;
            return View();
        }
        [HttpPost]
        public ActionResult NhapHang(PhieuNhap model , IEnumerable<CTPN> lstModel)
        {
            CTPNDao dao = new CTPNDao();
            ViewBag.ID_NCC = db.NhaCungCaps;
            ViewBag.ListSanPham = db.Products;
            model.DaXoa = false;
            db.PhieuNhaps.Add(model);
            db.SaveChanges(); // lưu lại để có id phiếu nhập vì nó là identity
            Product sp;
            foreach(var item in lstModel)
                
            {
                // tận dụng loop này cập nhật số lượng tồn 
                sp = db.Products.SingleOrDefault(n => n.ID_Product == item.ID_Product); // tìm ra sản phẩm dựa vào id sản phẩm
                sp.Quantity += item.SoLuong; // lấy số lượng đang có + thêm số lượng nhập
                // gán mã spham cho các chi tiết phiếu nhập
                item.ID_PhieuNhap = model.ID_PhieuNhap;

            }
            foreach(var item in lstModel)
            {
                dao.Add(item);
            }
            
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult NhapHangDon(PhieuNhap pn ,CTPN ctpn)
        {
           ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.Name),"MaNCC","TenNCC",pn.ID_NCC);
            pn.DaXoa = false;
            db.PhieuNhaps.Add(pn);
            db.SaveChanges(); // lưu lại để có id phiếu nhập vì nó là identity
            ctpn.ID_PhieuNhap = pn.ID_PhieuNhap;
            Product product = db.Products.SingleOrDefault(n => n.ID_Product == ctpn.ID_Product);
            product.Quantity += ctpn.SoLuong;
            db.CTPNs.Add(ctpn);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult NhapHangDon(int? id)
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.Name),"MaNCC", "TenNCC");
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            Product sp = db.Products.SingleOrDefault(n => n.ID_Product == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);

        }
        [HttpGet]
        public ActionResult DSSPHetHang()
        {
             List<Product> lstSP = db.Products.Where(n => n.Quantity <= 5).ToList();
            return View(lstSP);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                }
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}