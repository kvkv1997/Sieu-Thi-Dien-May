using Model.DAO;
using SieuThiDienMay.Areas.Admin.Models;
using SieuThiDienMay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiDienMay.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               
                var dao = new EmployeeDao();
               
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                switch(result)
                {
                    case 1:
                    var user = dao.getByID(model.UserName);
                    var userSession = new EmployeeLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID_Employee;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                    case 0:
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    break;
                    case -1:
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                    break;
                    case -2:
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                    break;
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng.");
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }
}