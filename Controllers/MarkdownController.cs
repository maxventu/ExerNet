using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exernet.Controllers
{
    public class MarkdownController : Controller
    {
        //
        // GET: /Markdown/
        public ActionResult Markdown(String input) 
        {
            var md = new MarkdownDeep.Markdown();
            // Set options
            md.ExtraMode = true;
            md.SafeMode = false;
            string output = md.Transform(input);
            return View();
        }

    }
}