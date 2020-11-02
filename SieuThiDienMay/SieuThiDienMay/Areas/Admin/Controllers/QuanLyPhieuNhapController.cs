
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
            db.SaveChanges();
            foreach(var item in lstModel)
            {
                item.ID_PhieuNhap = model.ID_PhieuNhap;
            }
            foreach(var item in lstModel)
            {
                dao.Add(item);
            }
            
            db.SaveChanges();
            return View();
        }
    }
}