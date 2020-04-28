using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebMVCEmail.Controllers
{
    public class HomeController : Controller
    {
        //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
        //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

        static void Execute()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mariabramnik@gmail.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("bramnik@hotmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //List<EmailAddress> tos = new List<EmailAddress>();
            //tos.Add(to);
            //var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextContent, htmlContent);
            var response =  client.SendEmailAsync(msg).Result;
        }
/*
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
        public ActionResult Email()
        {
            Execute();
            return Content($"Email sent");
        }
    }
}