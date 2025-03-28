using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    // Определяем класс для обновлений от Telegram
    public class Update
    {
        public long UpdateId { get; set; }
        public Message? Message { get; set; }
        // Другие свойства, такие как CallbackQuery, InlineQuery и т. д.
    }

    // Определяем класс для сообщений
    public class Message
    {
        public long MessageId { get; set; }
        public string? Text { get; set; }
        public User? From { get; set; }
        public Chat? Chat { get; set; }
        // Другие свойства, такие как Date, ReplyToMessage и т. д.
    }

    // Определяем класс для пользователей
    public class User
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        // Другие свойства
    }

    // Определяем класс для чатов
    public class Chat
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        // Другие свойства
    }

    [ApiController]
    [Route("[controller]")]
    public class TelegramController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Update update)
        {
            if (update?.Message != null)
            {
                // Логика обработки текстового сообщения
                var messageText = update.Message.Text;

                // Здесь вы можете добавить свою логику, например, ответить на сообщение
                // или выполнить какие-то действия в зависимости от текста сообщения.

                return Ok($"Received message: {messageText}");
            }

            return BadRequest("No message found in the update.");
        }
    }
}