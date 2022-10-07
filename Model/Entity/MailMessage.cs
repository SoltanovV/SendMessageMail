using System.Text.Json.Serialization;

namespace SendMessageEmail.Model.Entity;

/// <summary>
/// Mail и текст сообщения
/// </summary>
public class MailMessage
{
    /// <summary>
    /// Id сообщения
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Получатель сообщения
    /// </summary>
    public string Recepient { get; set; }

    /// <summary>
    /// Заголовок сообщения
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Сообщение
    /// </summary>
    public string Messages { get; set; }

    public DateTime SenddateTime { get;set; } = DateTime.Now;

    /// <summary>
    /// Id статуса сообщения
    /// </summary>
    [JsonIgnore]
    public int MessageStatusId { get; set; }

    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public MessageStatus MessageStatus { get; set; }
}
