using Exernet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Exernet.Filters;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Exernet.Controllers
{
    [Culture]
    public class TaskController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static int taskId;
        [HttpGet]
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
        public ActionResult CreateTask(ExernetTaskViewModel model,IEnumerable<HttpPostedFileBase> Images, string returnUrl)
        {
            ExernetTask task = new ExernetTask();
            task.Text = model.Text;
            task.Tags = GenerateTagsForTaskModel(model.Tags);
            task.Answers = GenerateAnswersForTaskModel(model.Answers);
            task.Title = model.Title;
            task.Category = model.Category;
            task.Block = true;
            task.UserId = User.Identity.GetUserId();
            task.UploadDate = DateTime.Now;
            task.Images = UploadPicturesOnCloudinary(Images);
            db.Tasks.Add(task);
            db.SaveChanges();
            taskId = db.Tasks.Local[0].Id;

            return RedirectToAction("PostTask");
        }



        private ICollection<Tag> GenerateTagsForTaskModel(string tags)
        {
            string[] listOfTags = tags.Split(' ', ',', ';');

            List<Tag> Tags = new List<Tag>();

            foreach (string str in listOfTags)
            {
                var tag = db.Tags.FirstOrDefault(obj => obj.Text == str);
                if (tag == null)
                {
                    tag = new Tag();
                    tag.Text = str;
                }
                Tags.Add(tag);
            }
            return Tags;
        }

        private ICollection<Answer> GenerateAnswersForTaskModel(string term)
        {
            string[] listOfTags = term.Split(' ', ',', ';');

            List<Answer> answers = new List<Answer>();

            foreach (string str in listOfTags)
            {
                Answer answer = new Answer();
                answer.Text = str;
                answers.Add(answer);
            }
            return answers;
        }

        public ActionResult PostTask(int? id)
        {

            var task = new ExernetTask();
            if (id == null)
            {
                task = db.Tasks.Find(taskId);
            }
            else
            {
                task = db.Tasks.Find(id);
            }


            return View(task);
        }

        public JsonResult TagSearch(string term)
        {

            var tags = db.Tags.Select(obj => obj.Text);

            return Json(tags, JsonRequestBehavior.AllowGet);
        }

        private List<Tag> GetTag(string searchString)
        {
            var tags = db.Tags.Where(a => a.Text.Contains(searchString)).ToList();
            return tags;

        }

        private List<Image> UploadPicturesOnCloudinary(IEnumerable<HttpPostedFileBase> pictures) 
        {
            if (pictures == null) return null;
            List<Image> PictureUrls = new List<Image>();
            Cloudinary cloudinary = new Cloudinary(new Account(
           "goodcloud",
           "836668373272998",
           "HJ2Q7oe53Ru7muxKcpVj4ZdqVPQ"));
            foreach (var pic in pictures)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(pic.FileName, pic.InputStream),
                    Folder = "Exernet/TaskPictures"
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                var uplPath = uploadResult.Uri.AbsoluteUri;
                PictureUrls.Add(new Image(){ImageURL=uplPath});
            }
            return PictureUrls;
        }
    }
}