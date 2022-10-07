namespace SendMessageEmail.Services.Interfaice;

public interface IMessageServices
{
    public Task<MailMessage> SendMessageAsync(Message model);
}
