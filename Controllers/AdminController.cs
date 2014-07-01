using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
namespace project.Controllers
{
    
    public class AdminController : Controller
    {
        IUserRepository repo;

        public AdminController(IUserRepository u)
        {
            repo = u;
        }
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveFile()
        {
            for(int i=0;i<Request.Files.Count;i++)
            { 
            HttpPostedFileBase file = Request.Files[i];
            file.SaveAs(Server.MapPath(@"~\Files\"+file.FileName));
            }
            return View("../Home/Index");
        }
        [HttpPost]
        public ActionResult Save( Table t)
        {
            repo.addproduct(t);
            return View("../Home/Index");
        }

        
        public ActionResult Update()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Up(Table t)
        {
            bool a=repo.update(t);
            if (a)
            {
                return View("../Home/Index");
            }
            else
            {
                return View("../Admin/Index");
            }
        }

        public ActionResult delete()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult dlt(Table t)
        //{
        //    bool a = repo.(t);
        //    if (a)
        //    {
        //        return View("../Home/Index");
        //    }
        //    else
        //    {
        //        return View("../Admin/Index");
        //    }
        //}
    }
}
