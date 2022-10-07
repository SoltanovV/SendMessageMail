namespace SendMessageEmail.Services
{
    public class LoggerDbServices
    {
        private ApplicationContext _db;

        public LoggerDbServices(ApplicationContext db)
        {
            _db = db;
        }
        // Метод для проверки ошибок при отправке
        public async Task<MailMessage> LogerDb(Message model, Exception ex = null)
        {
           
            try
            {
                MessageStatus status = new MessageStatus();
                // Мапим данные в MailMessage
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Message, MailMessage>());
                var mapper = new Mapper(config);
                var result = mapper.Map<MailMessage>(model);

                // Проверка есть ли оисключение
                if (ex != null)
                {
                    status.Result = "Failed";
                    // Добавление логов об ошибке 
                    status.Log = ex.Message;
                    await _db.Status.AddAsync(status);
                    result.MessageStatus = status;

                    await _db.Mail.AddAsync(result);
                    await _db.SaveChangesAsync();

                    return result;
                }
                else
                {
                    status.Result = "Ok";
                    result.MessageStatus = status;

                    await _db.Mail.AddAsync(result);
                    await _db.Status.AddAsync(status);

                    await _db.SaveChangesAsync();

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
