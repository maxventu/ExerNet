using Exernet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Exernet.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public UserController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public UserController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Details/id
        public ActionResult Details(string id)
        {
            var user = UserManager.FindByName(id);
            if (user == null) return RedirectToAction("Index", "Home");
            var userInfo = new ShowUserViewModel()
            {
                CommentsQuantity = user.Comments.Count,
                Email = user.Email,
                Rating = user.Rating,
                ResolvedTasksQuantity = user.Solutions.Count(x => x.Correct),
                Solutions = user.Solutions,
                SolutionsQuantity = user.Solutions.Count,
                Tasks = user.Tasks,
                TasksQuantity = user.Tasks.Count,
                ProfileFotoURL=user.ProfileFotoURL,
                UserName=user.UserName
            };
            return View(userInfo);
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
