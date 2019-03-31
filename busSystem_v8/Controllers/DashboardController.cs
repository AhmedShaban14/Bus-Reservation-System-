using busSystem_v8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace busSystem_v8.Controllers
{
    public class DashboardController : Controller
    {
        BusSystemDB db = new BusSystemDB();
        // GET: Dashboard
        User info;
        public ActionResult index1()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult app_profile()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult chart_amchart()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }

        public ActionResult email_compose()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult email_inbox()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult email_read()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult layout_blank()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult layout_boxed()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult layout_fix_header()
        {

            return View();
        }
        public ActionResult busUser(int x=6)
        {
            var bu = db.users.Where(m => m.bus_id == x).ToList();
            return View(bu);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var u = db.users.Find(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var u = db.users.Find(user.UserID);
                u.wallet = user.wallet;
                db.SaveChanges();
            }
            return RedirectToAction("busUser");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var u = db.users.Find(id);
                db.users.Remove(u);
                db.SaveChanges();
            }
            return RedirectToAction("busUser");
        }
        public ActionResult block(int id)
        {
            if (ModelState.IsValid)
            {
                var u = db.users.Find(id);
                u.user_status_id = 1;
                db.SaveChanges();
            }
            return RedirectToAction("busUser");
        }
        public ActionResult layout_fix_sidebar()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult map_google()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult map_vector()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult page_error_400()
        {
            return View();
        }

        public ActionResult page_error_500()
        {
            return View();
        }
    }
}