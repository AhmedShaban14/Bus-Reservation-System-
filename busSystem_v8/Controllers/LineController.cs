using busSystem_v8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace busSystem_v8.Controllers
{
    public class LineController : Controller
    {
        BusSystemDB DB = new BusSystemDB();
        User info;
        /*****************************  all lines *****************************/
        [HttpGet]
        public ActionResult AllLines()
        {
            var line = DB.lines.ToList();
            
            return View(line);
        }

        /**************************    Add lines ***************************/
        // GET: Line
        [HttpGet]
        public ActionResult AddLine()
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

        [HttpPost]
        public ActionResult AddLine(Line l)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    if (ModelState.IsValid)
                    {
                        DB.lines.Add(l);
                        DB.SaveChanges();
                        return Json(new { result = 1 });
                    }
                    return Json(new { result = 0 });
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
            #region
            /*
            if(!ModelState.IsValid)
            {
                return View("AddLine", l);
            }
            DB.lines.Add(l);
            DB.SaveChanges();

            return RedirectToAction ("AllLines");
            */
            #endregion
        }

        /***************************** Edit line ***************************/
        [HttpGet]
        public ActionResult EditLine(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var line = DB.lines.Single(c => c.Id == id);
                    return View(line);
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

        [HttpPost]
        public ActionResult EditLine(Line l)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    if (ModelState.IsValid)
                    {
                        var lineDB = DB.lines.Single(c => c.Id == l.Id);

                        lineDB.From = l.From;
                        lineDB.To = l.To;
                        lineDB.NumOfBuses = l.NumOfBuses;
                        lineDB.NumOfHours = l.NumOfHours;

                        DB.SaveChanges();

                        return Json(new { result = 1 });
                    }

                    return Json(new { result = 0 });
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
            #region
            /*
            if (!ModelState.IsValid)
            {
                return View("EditLine", l);
            }
            var lineDB = DB.lines.Single(c => c.Id == l.Id);

            lineDB.From = l.From;
            lineDB.To = l.To;
            lineDB.NumOfBuses = l.NumOfBuses;
            lineDB.NumOfHours = l.NumOfHours;

            DB.SaveChanges();

            return RedirectToAction("AllLines");
            */
            #endregion
        }
        /********************************  show line ****************************/

        [HttpGet]
        public ActionResult showLine(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var line = DB.lines.Single(c => c.Id == id);
                    return View(line);
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
        /**************************** Delete Line ***********************************/
        [HttpGet]
        public ActionResult DeleteLine(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var line = DB.lines.SingleOrDefault(c => c.Id == id);
                    DB.lines.Remove(line);
                    // DB.Entry(line).State = EntityState.Deleted;
                    DB.SaveChanges();
                    return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
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
            // return RedirectToAction("AllLines");
        }

    }
}