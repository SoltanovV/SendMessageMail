namespace SendMessageEmail.Services.Interfaice;

public interface IMessageServices
{
    // Интрерфейс для отправки сообщений
    public Task<MailMessage> SendMessageAsync(Message model);
}
