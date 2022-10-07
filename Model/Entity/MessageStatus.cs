using System.Text.Json.Serialization;

namespace SendMessageEmail.Model.Entity
{
    /// <summary>
    /// Статус сообщения
    /// </summary>
    public class MessageStatus
    {
        /// <summary>
        /// Id статуса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Результата отправки
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Логинрование  
        /// </summary>
        public string? Log { get; set; }

        /// <summary>
        /// Навигационное свойсво
        /// </summary>
        [JsonIgnore]
        public IEnumerable<MailMessage> MailMessage { get; set; }
    }
}
