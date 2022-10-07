using Microsoft.AspNetCore.Mvc;

namespace SendMessageEmail.Controllers
{

    public class MailController : ControllerBase
    {
        private ApplicationContext _db;
        private readonly ILogger<MailController> _logger;
        private IMessageServices _sendMess;
        public MailController(ApplicationContext db, ILogger<MailController> logger, IMessageServices sendMess)
        {
            _db = db;
            _logger = logger;
            _sendMess = sendMess;
        }
        [HttpPost]
        [Route("api/mails")]
        // Полученние данных с клиента  
        public async Task<IActionResult> SendMessage([FromBody]Message model)
        {
            try
            {
                _logger.LogInformation("Запрос SendMessage получен");

                // передача данных в сервис
                var result = await _sendMess.SendMessageAsync(model);

                _logger.LogInformation("Запрос SendMessage выполнен");
                return Ok(result);
            }
            catch (Exception ex)
            { 
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/mails")]
        // api для получения списка отправленных запросов
        public async Task<IActionResult> GetMessage()
        {
            try
            {
                _logger.LogInformation("Запрос GetMessage получен");
                // Получение списка
                var result = _db.Mail.Include(m => m.MessageStatus);

                _logger.LogInformation("Запрос GetMessage выполнен");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
