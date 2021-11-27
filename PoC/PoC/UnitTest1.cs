using NUnit.Framework;

namespace PoC
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IEmailer emailer = EmailManager.GetEmailer(EmailerType.SENDGRID);
            Email email = new Email
            {
                Sender = "email@domain.com",
                EmailContentType = EmailContentType.HTML,
                Subject = "This is the subject",
                Content = "This is the body",
                Recipients = new System.Collections.Generic.List<string>{
                    "recipient@domain.com"
                }
            };
            emailer.SendAsync(email);
            Assert.Pass();
        }
    }
}