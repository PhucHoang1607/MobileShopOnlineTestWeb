using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Controllers
{
    public class MenuNavPartialController : Controller
    {
        MobileShopOnlineEntities1 db = new MobileShopOnlineEntities1();
        // GET: MenuNavPartial
        public ActionResult MenuNav()
        {
            ViewBag.CategoryNavList = db.Categories.ToList();
            return PartialView();
        }
    }
}