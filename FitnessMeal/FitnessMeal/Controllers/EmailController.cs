using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessMeal.Models;

namespace FitnessMeal.Controllers
{
    public class Email
    {
        private FitnessMealModel db = new FitnessMealModel();
        private const String API_KEY = "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";


        public Boolean Send(int orderID, String subject, String contents)
        {
            var userID = db.RESERVE_PICK_UP.Find(orderID).USER_ID;
            var toEmail = db.USERs.Find(userID).EMAIL;
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@FitnessMeal.com", "Fitness meal");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);

            return true;
        }

    }
}