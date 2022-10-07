namespace SendMessageEmail.ViewModel
{
    /// <summary>
    /// Предстваление модели для MailMessage
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Email получателя
        /// </summary>
        public string Recepient { get; set; }

        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текс письма
        /// </summary>
        public string Messages { get; set; }
    }
}
