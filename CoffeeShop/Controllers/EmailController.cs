namespace CoffeeShop.Controllers
{
    using System;
    using System.Net.Mail;
    using System.Web.Http;

    using CoffeeShop.Lib.WebApi;
    using CoffeeShop.Models;
    using CoffeeShop.Properties;

    using NLog;

    public class EmailController : ApiController
    {
        #region Fields

        private Logger _logger;

        #endregion

        #region Properties

        private Logger Logger => _logger ?? (_logger = LogManager.GetLogger("CoffeeShop"));

        #endregion

        #region Public Methods and Operators

        public void Post(Email email)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(Settings.Default.EmailFrom);
                        mailMessage.To.Add(Settings.Default.EmailTo);
                        mailMessage.Subject = $"Meddelande från {email.From} via hemsidan";
                        mailMessage.Body = email.Message;
                        mailMessage.IsBodyHtml = false;

                        smtpClient.Send(mailMessage);
                    }
                }
            }

            catch (Exception ex)
            {
                Logger.Error(ex, "Could not send email");
                Request.ThrowHttpErrorResponse("Något gick snett när vi skulle skicka meddelandet. Du kan testa igen eller slå oss en signal istället.");
            }
        }

        #endregion
    }
}
