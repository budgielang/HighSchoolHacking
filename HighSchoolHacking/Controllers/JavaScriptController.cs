using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HighSchoolHacking.Controllers
{
    public class JavaScriptController : Controller
    {
        public ActionResult Index(string section = "Index")
        {
            return View(section);
        }
    }
}