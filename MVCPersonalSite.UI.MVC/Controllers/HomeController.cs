using System.Web.Mvc;
using MVCPersonlSite.UI.MVC.Models;
using System;
using System.Net.Mail; // mail
using System.Net; // mail

namespace MVCPersonlSite.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ContactAjax(ContactViewModel cvm)
        {
            //You can make this whatever you want, it will be the body of the message sent
            string body = $"{cvm.Name} has sent you the following message: <br />" + $"{cvm.Message} <strong> from the email address: </strong> {cvm.Email}";

            //Message Object                 from your website to your personal email
            MailMessage m = new MailMessage("", "", cvm.Subject, body);

            //allow HTML in email (that is our formatting with br and strong tags above
            m.IsBodyHtml = true;

            //you can make it high priority
            m.Priority = MailPriority.High;

            //reply to the Person who filled out the form, not your domain email
            m.ReplyToList.Add(cvm.Email);

            //configure the mail client
            SmtpClient client = new SmtpClient("");
            //Configure email credentials
            client.Credentials = new NetworkCredential("", "");

            client.Port = 8889;

            try
            {
                //send mail
                client.Send(m);
            }
            catch (Exception e)
            {
                //log error in viewbag to be seen by admins
                ViewBag.Message = e.StackTrace;
            }
            return Json(cvm);
        }
        [HttpPost]
        public ActionResult Test()
        {
            return View();
        }
    }
}
