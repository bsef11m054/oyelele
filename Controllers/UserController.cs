using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
namespace project.Controllers
{
    public class UserController : Controller
    {
        IUserRepository repo;

        public UserController(IUserRepository u)
        {
            repo = u;
        }

        //
        // GET: /User/
        [ChildActionOnly]
        [ActionName("MyAction")]
        public PartialViewResult Partial4()
        {
            ViewBag.k1 = "abcd";
            return PartialView("Partial4");
        }
        public ActionResult SignUp()
        {
            var nam = Request["cat"];
            ViewBag.Catagory = nam;
            return View();
        }

        [HttpPost]
        public ActionResult Save(Models.User user)
        {
            if (ModelState.IsValid)
            {
                
                repo.Save(user);
                return RedirectToAction("../Home/Index");
                
            }

            return RedirectToAction("../User/SignUp");
        }

        public JsonResult check()
        {
            var nam = Request["cat"];
            //var pass = Request["p1"];
            
            bool value = repo.Check(nam);

            if (value == true)
            {
                return this.Json("Write New Name", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json("Succesful", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
              //  String a = user.Email;
                if(repo.login(user))
                    
                {
                    
                    Session["login"] = user.Email;

                    
                }
                else
                {
                    Session["login"] = null;
                }

                return RedirectToAction("../Home/Index");    
                

            }
            return RedirectToAction("../Home/Index");
            
        }
        
        [HttpGet]
        public JsonResult search()
        {
            var nam = Request["cat"];
            
            List<User> list = repo.search(nam);
            
            return this.Json(list, JsonRequestBehavior.AllowGet);
           
        }

        [HttpGet]
        public ActionResult se()
        {
            var nam = Request["cat"];

            List<Table> list = repo.se(nam);

            ViewBag.Catagory = list;
            return View();

        }

        [ChildActionOnly]
        [ActionName("MyAction")]
        public PartialViewResult Wq()
        {
            ViewBag.k1 = "abcd";
            return PartialView("Wq");
        }

        [HttpGet]
        public ActionResult additem()
        {
            var nam = Request["item"];
            if (Session["login"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            var e = Session["login"];
            String t = e.ToString();
            bool list = repo.addcart(nam, t);

            ViewBag.Catagory = list;
            return RedirectToAction("../Home/Index");

        }
        public ActionResult ViewCart()
        {
            List<Cart> list = new List<Cart>();
          //  var nam = Request["item"];
            if(Session["login"]!=null)
            {
                var e = Session["login"];
            String t = e.ToString();
             list = repo.ViewCart(t);
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
            ViewBag.Catagory = list;
            return View();

        }
        
    }


}
