using FluentEmail.Core;
using HalcyonApparelsMVC.Interfaces;
using HalcyonApparelsMVC.Models;
using System.Net.Mail;
using System.Net;

namespace HalcyonApparelsMVC.Services
{
    public class MailSender : IMailSender
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _config;
        public MailSender(IServiceProvider serviceProvider, IConfiguration config)
        {
            _serviceProvider = serviceProvider;
            _config = config;
        }

        private bool SendEmail(string recepientEmail)
        {
            try
            {
                string HostAdd = _config.GetSection("Gmail")["ServerName"];
                string FromEmailid = _config.GetSection("Gmail")["Sender"];
                var gmailPassword = _config.GetSection("Gmail")["Password"];
                string SMTPPort = _config.GetSection("Gmail")["Port"];
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmailid);
                mailMessage.Subject = "Test Subject";
                //mailMessage.Body = "Test Message";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = System.IO.File.ReadAllText($"{Directory.GetCurrentDirectory()}/wwwroot/emails/Mixed.cshtml");
                //mailMessage.Body = System.IO.File.ReadAllText($"{Directory.GetCurrentDirectory()}/wwwroot/watches/Shoes.cshtml");
                //foreach (string ToEMailId in recepientEmails)
                {
                    mailMessage.To.Add(new MailAddress(recepientEmail));
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAdd;
                smtp.EnableSsl = true;
                smtp.Port = Convert.ToInt32(SMTPPort);
                smtp.Credentials = new NetworkCredential(FromEmailid, gmailPassword);
                smtp.Send(mailMessage);
                throw new Exception("test");
                return true;
            }
            catch (Exception ex)
            {

                // Folder, where a file is created.  
                // Make sure to change this folder to your own folder  
                string folder = @"C:\Temp\";
                // Filename  
                string fileName = "Mailsender.txt";
                // Fullpath. You can direct hardcode it if you like.  
                string fullPath = folder + fileName;
                // An array of strings  
                string[] authors = { ex.Message,ex.StackTrace };
                // Write array of strings to a file using WriteAllLines.  
                // If the file does not exists, it will create a new file.  
                // This method automatically opens the file, writes to it, and closes file  
                File.WriteAllLines(fullPath, authors);
                // Read a file  
                string readText = File.ReadAllText(fullPath);
                Console.WriteLine(readText);
                return false;
            }
        }
     
       

        public async void SendBulkMail(IEnumerable<string> recepientEmails)
        {
            foreach (var mailid in recepientEmails)
            {
                SendEmail(mailid);

            }
        }
    }
}