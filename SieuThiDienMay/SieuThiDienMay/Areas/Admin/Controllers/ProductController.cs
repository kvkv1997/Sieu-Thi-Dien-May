using System;
using System.Web.Mvc;
using Model2;
using Model2.DAO;

namespace SieuThiDienMay.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        SieuThiDienMayDbContext db = new SieuThiDienMayDbContext();

        public ActionResult Index(int page = 1 , int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.GetAll(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            setViewBag();
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Add([System.Web.Http.FromBody] Product pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductDao.Insert(pro);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            else
                ViewBag.Message = "Kiểm tra lại dữ liệu nhập";
            setViewBag(pro.NhaCungCap);
            return View(pro);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var model = ProductDao.getByID(id);
          
            if(model == null)
            {
                ViewBag.Message = "Mã sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }
            setViewBag(model.NhaCungCap);
            return View("Add", model);
        }
        [HttpPost]
        public ActionResult Edit([System.Web.Http.FromBody] Product pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductDao.Update(pro);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            else
                ViewBag.Message = "Kiểm tra lại dữ liệu nhập";
            setViewBag(pro.NhaCungCap);
            return View("Add", pro);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pro = ProductDao.getByID(id);
            if(pro == null)
            {
                ViewBag.Message = "Sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }
            return View(pro);
        }
        [HttpPost]
        public ActionResult DeletePost([System.Web.Http.FromBody] int MaSp)
        {
            var pro = ProductDao.getByID(MaSp);
            if (pro == null)
            {
                ViewBag.Message = "Sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }
            ProductDao.Delete(MaSp);
            return RedirectToAction("Index");

        }
        public void setViewBag(string selectedID = null)
        {
            var dao = new NhaCungCapDao();
            ViewBag.NhaCungCap = new SelectList(dao.ListAll(),"ID_NCC","Name",selectedID);
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