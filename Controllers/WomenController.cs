using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class WomenController : Controller
    {
        //
        // GET: /Women/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Jewellery()
        {
            return RedirectToAction("Index");
        }
        public ActionResult ShalwarKameez()
        {
            return View();
        }
        public ActionResult Shawls()
        {
            return View();
        }
        public ActionResult Shoes()
        {
            return View();
        }
        public ActionResult Bags()
        {
            return View();
        }

    }
}
