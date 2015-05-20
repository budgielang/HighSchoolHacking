using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HighSchoolHacking.Models;

namespace HighSchoolHacking.Controllers
{
    public class CSharpController : Controller
    {
        public ActionResult Index(string section = "")
        {
            if (String.IsNullOrWhiteSpace(section) || section == "Index")
            {
                return View("~/Views/CSharp/Index.cshtml");
            }

            if (Languages.CSharp.CustomPages.Contains(section))
            {
                return View(Languages.GetSectionPage("CSharp", section), Languages.CSharp);
            }

            return View(Languages.GetSharedPage(section), HighSchoolHacking.Models.Languages.CSharp);
        }
    }
}