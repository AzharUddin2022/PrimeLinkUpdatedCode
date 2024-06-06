using System.Net.Mail;
using System.Net;
using System;

namespace PrimLink.Utility
{
    public class EmailUtility
    {
        public static void SendEmail(string toAddress, string subject, string body, ConfigurationModel mailServer)
        {
            try
            {
                //avoid error at users without a valid email address // done
                if (toAddress != null && toAddress != "")
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(mailServer.FromAddress),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,
                        Priority = MailPriority.High
                    };
                    mailMessage.To.Add(new MailAddress(toAddress));

                    var client = new SmtpClient(mailServer.Server)
                    {
                        EnableSsl = (bool)mailServer.TLS,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(mailServer.UserName, mailServer.Password),
                        DeliveryMethod = SmtpDeliveryMethod.Network,

                    };
                    var ServerParts = client.Host.Split(':');
                    if (ServerParts.Length > 1)
                    {
                        client.Host = ServerParts[0];
                        client.Port = Convert.ToInt16(ServerParts[1]);
                    }
                    if ((mailMessage.To.ToString() != "") && (mailMessage.To != null))
                    {
                        client.Send(mailMessage);
                    }
                }
            }
            catch
            {
            }

        }

    }
}
