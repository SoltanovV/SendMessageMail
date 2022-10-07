
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace SendMessageEmail.Services
{
    public class MessageServices: IMessageServices
    {
        private IConfiguration _configuration;
        private LoggerDbServices _loggerDb;
        private ApplicationContext _db;
    
        public MessageServices(IConfiguration configuration, ApplicationContext db, LoggerDbServices loggerDb)
        {
            _configuration = configuration;
            _db = db;
            _loggerDb = loggerDb;
        }
        public async Task<MailMessage> SendMessageAsync(Message model)
        {
            try
            {
                MailSettings _mailSet = new MailSettings();

                // Добавление файла конфигурации и проецировании на класс MailSettings
                _configuration.GetSection(MailSettings.SectionName).Bind(_mailSet);
               
                var emailMessage = new MimeMessage();

                // Заполнение данными письмо
                emailMessage.From.Add(new MailboxAddress("Тема письма", _mailSet.Login));
                //
                emailMessage.To.Add(new MailboxAddress("sd", model.Recepient));
                // Добавляет тему к пиьсму
                emailMessage.Subject = model.Subject;

                // Добавляет и конвертирует текс в html формат
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = model.Messages
                };

                // Авторизируемся в аккаунте и отправляем письмо
                using (var client = new SmtpClient())
                {
                    // Настройка подключения 
                    await client.ConnectAsync(_mailSet.SmtpDomen, _mailSet.Port, _mailSet.SSL);

                    // Авторизация в аккаунте
                    await client.AuthenticateAsync(_mailSet.Login, _mailSet.Password);

                    // Отправка сообщения
                    await client.SendAsync(emailMessage);

                    // 
                    await client.DisconnectAsync(true);

                }
                var result = await _loggerDb.LogerDb(model);



                return result;
            }
            catch(Exception ex)
            {
                var result = await _loggerDb.LogerDb(model, ex);
               return result;

            }

        }
    }
}
