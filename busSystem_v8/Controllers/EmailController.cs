using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using busSystem_v8.Models;
namespace busSystem_v8.Controllers
{
    public class EmailController : Controller
    {
        User info;
        // GET: Email
        public ActionResult Index()
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
        public ActionResult Index(gmail model)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    #region
                    /*
                    model.from > ايميل الراسل
                    model.to > ايميل اللى رايحاله الرسالة
                    model.pass > الباسورد بتاع الراسل"اللى باعت الميل"ــ
                    */
                    #endregion
                    MailMessage mm = new MailMessage(model.from, model.to);
                    mm.Subject = model.subject;
                    mm.Body = model.body;
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    NetworkCredential nc = new NetworkCredential(model.from, model.pass);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = nc;
                    smtp.Send(mm);
                    ViewBag.msg = "Email has been sended !";
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
    }
}