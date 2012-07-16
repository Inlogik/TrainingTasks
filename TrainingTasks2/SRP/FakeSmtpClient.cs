using System.Net.Mail;

namespace TrainingTasks2.SRP
{
    public class FakeSmtpClient
    {
        public void Send(MailMessage mailMessage)
        {
            // Do nothing
        }
    }
}