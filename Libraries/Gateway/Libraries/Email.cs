using System;
using System.Net;
using System.Net.Mail;

namespace Gateway.Libraries
{
    public class Email
    {
        public static bool GmailSendEmail(string Body, string MailTo, string subject)
        {
            var blnSent = true;
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress("no-reply@siamraj.com");
                mail.Sender = new MailAddress("no-reply@siamraj.com");
                mail.To.Add("parin.k@siamraj.com");
                mail.IsBodyHtml = true;
                mail.Subject = "Email Sent";
                mail.Body = "Body content from";

                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials =
                    new NetworkCredential(
                        "p.kanthakamala@gmail.com",
                        "griktvtwi@WSS01",
                        "smtp.gmail.com"
                    );
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Timeout = 30000;
                try
                {
                    smtp.Send(mail);
                }
                catch (SmtpException e)
                {
                    Console.WriteLine(e.Message);
                }


                // var smtpClient = new SmtpClient("smtp.gmail.com", 465);
                // var fromAddress = new MailAddress("no-reply@siamraj.com", "Title Mail System Notify");
                //
                // smtpClient.UseDefaultCredentials = true;
                // smtpClient.Credentials = new NetworkCredential("p.kanthakamala@gmail.com", "griktvtwi@WSS01");
                // smtpClient.EnableSsl = true;
                // //
                // var message = new MailMessage();
                // message.From = fromAddress;
                // //message.CC = sCc;
                // message.Subject = subject;
                //
                // //Set IsBodyHtml to true means you can send HTML email.
                // message.IsBodyHtml = true;
                //
                // message.Priority = MailPriority.High;
                // message.Body = Body;
                // var mail = MailTo.Split(',');
                // foreach (var s in mail)
                // {
                //     if (s != "")
                //     {
                //         message.Bcc.Add(new MailAddress(s));
                //     }
                // }
                //
                // message.Sender = fromAddress;
                // smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return blnSent;
        }
    }
}