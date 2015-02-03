using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HighSchoolHacking.Models;

namespace HighSchoolHacking.Controllers
{
    public class PythonController : Controller
    {
        public ActionResult Index(string section = "")
        {
            if (String.IsNullOrWhiteSpace(section) || section == "Index")
            {
                return View("~/Views/Python/Index.cshtml");
            }

            if (Languages.Python.CustomPages.Contains(section))
            {
                return View(Languages.GetSectionPage("Python", section), Languages.JavaScript);
            }

            return View(Languages.GetSharedPage(section), HighSchoolHacking.Models.Languages.Python);
        }
    }
}