using JWL.DB;
using JWL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWL.Web.Controllers
{
    public class PhoneController : Controller
    {
        //
        // GET: /Phone/

        TrendService ts = new TrendService();
        LorryService ls = new LorryService();
        UserService us = new UserService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var uname = us.CheckUser(user.PhoneNo, user.Password);
            if (!string.IsNullOrEmpty(uname)) {
                Session["UserName"] = uname;
                return Json(new { res = true });
            }
            return Json(new { res = false });
        }

        public ActionResult Publish()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Publish(Trend trend)
        {
            if (Session["UserName"] != null) {
                var lorry = ls.GetLorryByUserName(Session["UserName"].ToString());
                trend.Lorry = lorry;
                trend.LorryNo = lorry.No;
            }
            ts.Add(trend);
            return View();
        }

        public ActionResult Query()
        {
            return View();
        }
        public ActionResult Mine()
        {
            return View();
        }


    }
}
