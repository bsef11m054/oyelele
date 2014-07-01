using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
namespace project.Controllers
{
    public class WomensClothingController : Controller
    {
        IUserRepository repo;

        public WomensClothingController(IUserRepository u)
        {
            repo = u;
        }
        //
        // GET: /WomensClothing/

        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        [ActionName("MyAction")]
        public PartialViewResult WC()
        {
            ViewBag.k1 = "abcd";
            return PartialView("WC");
        }

        [HttpGet]
        public ActionResult ShalwarKameez()
        {
            var nam = Request["so"];
          //  Session["login"] = "abc";
            List<Table> list = repo.se(nam);

            ViewBag.Catagory = list;
            return View();

            
        }
    }
}
