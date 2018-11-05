using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PictoHub.Models;
using PictoHub.Models.Hub;

namespace PictoHub.Controllers
{
    public class ThreadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Threads
        public ActionResult Index(int? id)
        {
            if (id == null)
                return HttpNotFound();
            ViewBag.Board = id;
            return View(db.Threads.ToList().Where(t => t.Board == id));
        }

        // GET: Threads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null && TempData["thread"] != null)
                id = (int) TempData["thread"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            thread.GetComments(db);
            return View(thread);
        }

        // GET: Threads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // POST: Threads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Board,Title,Content,Author")] Thread thread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thread).State = EntityState.Modified;
                db.SaveChanges();
                TempData["thread"] = thread.Id;
                return RedirectToAction("Details");
            }
            return View(thread);
        }

        [HttpPost]
        public ActionResult Reply(int id, string comment, HubColor color) {
            if(User.IsInRole("Banned")) {
                return HttpNotFound();// banned users can't post replies.
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null) {
                System.Diagnostics.Debug.WriteLine("nulled");
                return HttpNotFound();
            }
            thread.AddComment(db, new Models.Hub.Comment(User.Identity.Name, comment, color));
            TempData["thread"] = thread.Id;
            return RedirectToAction("Details");
        }

        // GET: Threads/Create
        public ActionResult Create(int? id) {
            if (id == null) {
                return HttpNotFound();
            }
            ViewBag.Board = id;
            return View();
        }

        // POST: Threads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "Id,Title,Content,Author,Color")] Thread thread) {
            if (User.IsInRole("Banned")) {
                return HttpNotFound();// banned users can't post threads.
            }
            if (id == null) {
                return HttpNotFound();
            }
            thread.Board = id.Value;
            thread.Date = DateTime.Now;
            ViewBag.Board = thread.Board;
            if (ModelState.IsValid) {
                db.Threads.Add(thread);
                db.SaveChanges();
                return View("Index", db.Threads.ToList().Where(t => t.Board == thread.Board));
            }

            return View(thread);
        }

        // GET: Threads/Delete/5
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Mod")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        // POST: Threads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Mod")]
        public ActionResult DeleteConfirmed(int id)
        {
            Thread thread = db.Threads.Find(id);
            db.Threads.Remove(thread);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
