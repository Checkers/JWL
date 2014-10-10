using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JWL.DB;
using JWL.Service;
using JLib.Extension;

namespace JWL.Web.Controllers
{
    public class UserCenterController : Controller
    {
        //
        // GET: /UserCenter/
        UserService us = new UserService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.AllowTime = DateTime.Now;
            user.RegTime = DateTime.Now;
            user.Password = user.Password.GetMD5("1d53");
            try
            {
                us.Add(user);
                return Json(new { res = "注册成功" });
            }
            catch (Exception)
            {
                return Json(new { res = "注册失败" });
            }
        }

        public ActionResult UserExit()
        {
            Session["UserName"] = null;
            return Redirect("/");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            var res = us.CheckUser(UserName, Password);
            if (res != null) {
                Session["UserName"] = res;
                return Json(new { res = "登录成功" });
            }
            else return Json(new { res = "登录失败" });
        }

        public ActionResult UpadateUserInfo()
        {
            return View();
        }

        public ActionResult Published()
        {
            return View();
        }

    }
}
