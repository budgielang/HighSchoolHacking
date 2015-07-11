using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HighSchoolHacking.Models;

namespace HighSchoolHacking.Controllers
{
    public class RubyController : Controller
    {
        public ActionResult Index(string section = "")
        {
            if (String.IsNullOrWhiteSpace(section) || section == "Index")
            {
                return View("~/Views/Python/Index.cshtml");
            }

            if (Languages.Ruby.CustomPages.Contains(section))
            {
                return View(Languages.GetSectionPage("Ruby", section), Languages.Python);
            }

            return View(Languages.GetSharedPage(section), HighSchoolHacking.Models.Languages.Python);
        }
    }
}