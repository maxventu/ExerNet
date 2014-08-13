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
using System.Text.RegularExpressions;

namespace Exernet.Controllers
{
    [Culture]
    public class TaskController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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
        public ActionResult CreateTask(ExernetTaskViewModel model, string returnUrl)
        {
            ExernetTask task = new ExernetTask(); ;
            if (model.Id != 0)
            {
                task = db.Tasks.Where(a => a.Id.Equals(model.Id)).First();
                task.Tags.Clear();
                task.Answers.Clear();
                task.Videos.Clear();
            }
            task.Text = model.Text;
            task.Tags = GenerateTagsForTaskModel(model.Tags);
            task.Answers = GenerateAnswersForTaskModel(model.Answers);
            task.Videos = GenerateVideosForTaskModel(model.Videos);
            task.Title = model.Title;
            task.Category = model.Category;
            task.Block = true;
            task.UserId = User.Identity.GetUserId();
            task.UploadDate = DateTime.Now;
            if (model.Id == 0)
            {
                db.Tasks.Add(task);
            }
            else
            {
                db.Entry(task).State = EntityState.Modified;
            }
            db.SaveChanges();

            return RedirectToAction("PostTask", new { id = GetId(model) });
        }

        private string[] parseForVideo(string[] listOfVideos) 
        {
            string pattern = @".+?/?v=";
            string replacement1 = "//www.youtube.com/embed/";
            for (int i = 0; i < listOfVideos.Length; i++)
            {
                listOfVideos[i] = Regex.Replace(listOfVideos[i], pattern, replacement1);
            }

            return listOfVideos;
        }
        private ICollection<Video> GenerateVideosForTaskModel(string p)
        {
            string[] listOfVideos = SplitString(p);
            listOfVideos = parseForVideo(listOfVideos);
            List<Video> Videos = new List<Video>();
            foreach (var str in listOfVideos)
            {
                var Video = new Video();
                Video.VideoURL = str;
                Videos.Add(Video);
            }
            return Videos;
        }

        private int GetId(ExernetTaskViewModel model)
        {
            int id;
            if (model.Id != 0)
            {
                id = model.Id;
            }
            else
            {
                id = db.Tasks.Local[0].Id;
            }
            return id;
        }

        private ICollection<Tag> GenerateTagsForTaskModel(string tags)
        {
            string[] listOfTags = SplitString(tags);

            var listOfTagsWithoutDuplicate = listOfTags.Distinct();

            List<Tag> Tags = new List<Tag>();

            foreach (string str in listOfTagsWithoutDuplicate)
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

        private string[] SplitString(string term)
        {
            string[] str = term.Split(new string[] { ", ", ",", "; ", ";" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].ToString().Trim();
            }
            return str;
        }


        private ICollection<Answer> GenerateAnswersForTaskModel(string term)
        {
            string[] listOfTags = SplitString(term);

            List<Answer> answers = new List<Answer>();

            foreach (string str in listOfTags)
            {
                Answer answer = new Answer();
                answer.Text = str;
                answers.Add(answer);
            }
            return answers;
        }

        public ActionResult PostTask(int id)
        {

            var task = new ExernetTask();
            task = db.Tasks.Find(id);


            return View(task);
        }

        public ActionResult EditTask(int id)
        {
            var model = db.Tasks.Find(id);
            ExernetTaskViewModel task = new ExernetTaskViewModel();

            task.Text = model.Text;
            task.Tags = GenerateStringTagsForTaskModel(model.Tags);
            task.Answers = GenerateStringAnswersForTaskModel(model.Answers);
            task.Videos = GenerateStringVideosForTaskModel(model.Videos);
            task.Title = model.Title;
            task.Category = model.Category;
            task.Id = id;
            return View(task);
        }

        private string GenerateStringVideosForTaskModel(ICollection<Video> collection)
        {
            string stringOfVideos = string.Join("; ", collection.Select(obj => obj.VideoURL));
            return stringOfVideos;
        }

        private string GenerateStringAnswersForTaskModel(ICollection<Answer> collection)
        {
            string stringOfAnswers = string.Join("; ", collection.Select(obj => obj.Text));
            return stringOfAnswers;
        }

        private string GenerateStringTagsForTaskModel(ICollection<Tag> collection)
        {
            string stringOfTags = string.Join(", ", collection.Select(obj => obj.Text));

            return stringOfTags;
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

        public ActionResult SetLike(int id)
        {
            var model = db.Tasks.Find(id);

            return View();
        }




    }
}