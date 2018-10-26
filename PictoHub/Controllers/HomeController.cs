﻿using PictoHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictoHub.Controllers {
    public class HomeController : Controller {

        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index() {
            return View(db.Boards.ToList());
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}