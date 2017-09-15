using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EddyHomepage.Controllers
{
    public class EddyHomeController : Controller
    {
        // GET: EddyHome
        public ActionResult Index()
        {
            return View();
        }
    }
}