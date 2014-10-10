using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWL.Web.Controllers
{
    public class TempleteController : Controller
    {
        //
        // GET: /Templete/

        public ActionResult UserLoginForm()
        {
            return PartialView("UserCenterList");
        }

        public ActionResult UCTopList()
        {
            return PartialView("UCTopList");
        }

    }
}
