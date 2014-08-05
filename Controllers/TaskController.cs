using Exernet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Exernet.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Markdown/
        public ActionResult CreateTask(String input) 
        {
            var md = new MarkdownDeep.Markdown();
            // Set options
            md.ExtraMode = true;
            md.SafeMode = false;
            string output = md.Transform(input);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(ExernetTask model, string returnUrl)
        {

            ExernetTask task = new ExernetTask();
            task.Text = model.Text;


            // If we got this far, something failed, redisplay form
            return View(model);
        }



    }
}