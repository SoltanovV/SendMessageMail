namespace SendMessageEmail.Services;

/// <summary>
/// Класс для проецирования настроек из файла appsettings.json
/// </summary>
public class MailSettings
{
    /// <summary>
    /// Название секции откуда берутся настройки
    /// </summary>
    public const string SectionName = "MailSettings";

    /// <summary>
    /// Сетевой протокол
    /// </summary>
    public string SmtpDomen { get; set; }

    /// <summary>
    /// Порт
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Протокол для связи
    /// </summary>
    public bool SSL { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; }


}
