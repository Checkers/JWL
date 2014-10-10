using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JWL.DB;
using JWL.Service;

namespace JWL.Web.Controllers
{
    public class HomeController : Controller
    {
        GoodService gs = new GoodService();
        UserService us = new UserService();
        TrendService ts = new TrendService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trucks()
        {
            var goods = gs.GetAll().OrderByDescending(t=>t.CreateTime).ThenByDescending(t=>t.UpdateTime).Take(8).ToList();
            return View(goods);
        }


        [ValidateInput(false)]
        public ActionResult AddGood(Good good)
        {
            try
            {
                if (Session["UserName"] == null) return Json(new { res = "请先登录~~" });
                good.User = us.GetSingle(t => t.UserName.Equals(Session["UserName"].ToString()));
                good.Title = string.Format("{0}/{1}吨/发往{2}", good.SrcAddress, good.Weight, good.DestAddress);
                good.UpdateTime = DateTime.Now;
                good.CreateTime = DateTime.Now;
                good.IsDel = false;
                gs.Add(good);
            }
            catch (Exception)
            {
                return Json(new { res = "发布失败~~" });
            }
           

            return Json(new { res = "发布成功啦~~" });
        }

        [HttpPost]
        public ActionResult　CheckUser(string UserName,string Password)
        {
            var res = us.CheckUser(UserName, Password);
            if (res != null)
            {
                Session["UserName"] = res;
                return Json(new { res = true });
            }
            else return Json(new { res = false });
        }

        [HttpPost]
        public ActionResult QueryTrend(int Gid)
        {
            var json = ts.GetTrendsByGid(Gid);
            return Json(new { res = json });
        }

    }
}
