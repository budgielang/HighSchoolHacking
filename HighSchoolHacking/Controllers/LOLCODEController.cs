using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HighSchoolHacking.Models;

namespace HighSchoolHacking.Controllers
{
    public class LOLCODEController : Controller
    {
        public ActionResult Index(string section = "")
        {
            if (String.IsNullOrWhiteSpace(section) || section == "Index")
            {
                return View("~/Views/LOLCODE/Index.cshtml");
            }

            if (Languages.LOLCODE.CustomPages.Contains(section))
            {
                return View(Languages.GetSectionPage("LOLCODE", section), Languages.LOLCODE);
            }

            return View(Languages.GetSharedPage(section), HighSchoolHacking.Models.Languages.LOLCODE);
        }
    }
}