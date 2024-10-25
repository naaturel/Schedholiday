using SchedHoliday.Models;
using SchedHoliday.ViewModels;
using System.Net.Mail;

namespace SchedHoliday.Services
{

    public interface IMailService
    {
        Task<bool> SendHelp(IViewModel<Mail> mail);
        Task<bool> SendConfirmation(string userEmail);
    }

    public class MailService : IMailService
    {

        private SmtpClient smtpClient ;
        
        public MailService() {
            smtpClient = new SmtpClient("smtp.helmo.be");
            smtpClient.Port = 25;
        }

        public Task<bool> SendHelp(IViewModel<Mail> mail)
        {    
            var send = mail.toModel();
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(send.Email);
                message.To.Add("s.jacquemin@student.helmo.be");
                message.Subject = send.Topic;
                message.Body = send.Message;

                smtpClient.Send(message);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> SendConfirmation(string userEmail)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("l.crema@student.helmo.be");
                message.To.Add(userEmail);
                message.Subject = "[SchedHoliday] Confirmation de votre compte";
                message.Body = 
                    "Veuillez confirmer votre compte en cliquant sur le lien ci-dessous" +
                    "\n https://porthos-intra.cg.helmo.be/Q210044/api/User/Confirm" +
                    "\nCordialement," +
                    "\nL'équipe SchedHoliday";

                smtpClient.Send(message);

                return Task.FromResult(true);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }         
            
        }

    }
}
