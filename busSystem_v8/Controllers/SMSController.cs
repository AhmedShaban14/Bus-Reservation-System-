using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Configuration;
using Twilio.TwiML;
using busSystem_v8.Models;


namespace busSystem_v8.Controllers
{
    public class SMSController : Controller
    {
        User info;
        [HttpGet]
        public ActionResult SendSms()
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
        public ActionResult SendSms(sms sms)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var accountSid = "AC46897a0b56a6a2660459976a95a26dc5";

                    var authToken = "a6e59bc47ad203cf654db8404fc768b9";

                    TwilioClient.Init(accountSid, authToken);

                    var to = new PhoneNumber(sms.to);
                    var message = MessageResource.Create(
                        to,
                        from: new PhoneNumber("+12075608670"),
                        body: sms.body);
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
