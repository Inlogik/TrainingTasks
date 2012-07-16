using System;
using System.Net.Mail;

namespace TrainingTasks2.SRP
{
    public class UserService
    {
        public void Register(string email, string password)
        {
            if (!email.Contains("@"))
                throw new Exception("Email is not an email!");

            var user = new User(email, password);
            var db = new FakeDatabase();
            db.Save(user);

            var smtpClient = new FakeSmtpClient();
            smtpClient.Send(new MailMessage("mysite@nowhere.com", email) { Subject = "Hello fool!" });
        }
    }
}
