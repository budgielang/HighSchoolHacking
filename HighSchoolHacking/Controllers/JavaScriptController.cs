using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HighSchoolHacking.Models;

namespace HighSchoolHacking.Controllers
{
    public class JavaScriptController : Controller
    {
        public ActionResult Index(string section = "")
        {
            if (String.IsNullOrWhiteSpace(section) || section == "Index")
            {
                return View("~/Views/JavaScript/Index.cshtml");
            }

            return View(Languages.GetSharedPage(section), HighSchoolHacking.Models.Languages.JavaScript);
        }
    }
}