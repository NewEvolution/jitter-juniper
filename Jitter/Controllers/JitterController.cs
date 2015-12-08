using System;
using System.Web;
using System.Linq;
using Jitter.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;

namespace Jitter.Controllers
{
    public class JitterController : Controller
    {

        public JitterRepo Repo { get; set; }

        public JitterController() : base()
        {
            Repo = new JitterRepo();
        }

        // GET: Jitter
        // Public feed here?
        public ActionResult Index()
        {
            List<Jot> the_jots = Repo.GetAllJots();
            return View(the_jots);
        }

        [Authorize]
        public ActionResult TopFavs()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserFeed()
        {
            string user_id = User.Identity.GetUserId();
            JitterUser current_user = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).Single();
            List<Jot> user_jots = Repo.GetUserJots(current_user);
            return View(user_jots);
        }

        // GET: Jitter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jitter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jitter/Create
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

        // GET: Jitter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jitter/Edit/5
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

        // GET: Jitter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jitter/Delete/5
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
