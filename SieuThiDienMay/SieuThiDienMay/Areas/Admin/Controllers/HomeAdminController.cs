
using Model2;
using Model2.DAO;
using SieuThiDienMay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiDienMay.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseController
    {
        SieuThiDienMayDbContext db = new SieuThiDienMayDbContext();
        //
        // GET: /Admin/Home/
        public ActionResult HomeIndex()
        {
            return View();
        }
        public ActionResult Menu()
        {
            EmployeeLogin user = (EmployeeLogin) Session["USER_SESSION"];
            EmployeeDao dao = new EmployeeDao();
            var emp = dao.getByID(user.UserName);
            LoaiTV ltv = db.LoaiTVs.SingleOrDefault(n => n.Type_Emp == emp.Type_Emp);
            if(ltv== null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiTVQuyen = db.Roles.Where(n => n.Type_Emp == emp.Type_Emp);

            return this.PartialView("_NavLeftBar.cshtml",ltv);
        }

        
    }
}