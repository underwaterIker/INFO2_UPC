using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace FlightLib
{
    public class Email
    {
        // Métodos
        public int SendEmailWithoutAttachment(string email, string subject, string body)
        // Sends an email to the user (without attachment). Returns 1 if there is no problem, 0 if email can't be send, -1 if user does not exist
        {
            try
            {
                MailMessage mmsg = new MailMessage();
                mmsg.To.Add(email);
                mmsg.Subject = subject;
                mmsg.SubjectEncoding = Encoding.UTF8;
                mmsg.Body = body;
                mmsg.BodyEncoding = Encoding.UTF8;
                mmsg.IsBodyHtml = false;
                mmsg.From = new MailAddress("info2version3@gmail.com");

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("info2version3@gmail.com", "info2V3M4");

                client.Port = 587;
                client.EnableSsl = true;

                client.Host = "smtp.gmail.com";

                try
                {
                    client.Send(mmsg);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int SendEmailWithAttachment(string email, string fileLoc)
        // Sends an email to the user (with attachment). Returns 1 if there is no problem, 0 if email can't be send, -1 if user does not exist
        {
            try
            {
                MailMessage mmsg = new MailMessage();
                mmsg.To.Add(email);
                mmsg.Subject = "File (.txt)";
                mmsg.SubjectEncoding = Encoding.UTF8;
                mmsg.Body = "The file is attached in this email.";

                Attachment attach = new Attachment(fileLoc);
                mmsg.Attachments.Add(attach);

                mmsg.BodyEncoding = Encoding.UTF8;
                mmsg.IsBodyHtml = false;
                mmsg.From = new MailAddress("info2version3@gmail.com");

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("info2version3@gmail.com", "info2V3M4");

                client.Port = 587;
                client.EnableSsl = true;

                client.Host = "smtp.gmail.com";

                try
                {
                    client.Send(mmsg);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
