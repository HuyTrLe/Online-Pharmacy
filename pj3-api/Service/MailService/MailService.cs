﻿using pj3_api.Database;
using pj3_api.Model;
using System.Net.Mail;
using System.Net;

namespace pj3_api.Service.Mail
{
    public class MailServiceApp : IMailService
    {
        private readonly Lazy<AppSettings> _appSetting;
        public MailServiceApp(AppSettings appSettings) {
            _appSetting = new Lazy<AppSettings>(() => appSettings);
        }

        public async Task<int> SendMail(MailParam mailService)
        {
            try
            {
            string smtpServer = _appSetting.Value.MailService.SMTP;
            int smtpPort = _appSetting.Value.MailService.Port; // Cổng SMTP của Gmail
            string smtpUsername = _appSetting.Value.MailService.UserName; // Điền địa chỉ email Gmail của bạn
            string smtpPassword = _appSetting.Value.MailService.Password; // Điền mật khẩu Gmail của bạn

            // Tạo đối tượng SmtpClient
            SmtpClient client = new SmtpClient(smtpServer);
            client.Port = smtpPort;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true; // Kích hoạt SSL để bảo mật kết nối

            // Tạo đối tượng MailMessage và gửi email
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpUsername);
            mail.To.Add(mailService.ToAddress); // Điền địa chỉ email người nhận
            mail.Subject = mailService.Subject;
            mail.Body = mailService.Body;
            if(mail.Attachments != null)
                mail.Attachments.Add(new Attachment(mailService.Attachments));


           
                client.Send(mail);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return 0;
            }
        }
    }
}
