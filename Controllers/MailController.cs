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
        public async Task<IActionResult> SendMessage(Message model)
        {
            try
            {
                _logger.LogInformation("Запрос SendMessage получен");

                var result = await _sendMess.SendMessageAsync(model);

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
        public async Task<IActionResult> GetMessage()
        {
            try
            {
                _logger.LogInformation("Запрос GetMessage получен");

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
