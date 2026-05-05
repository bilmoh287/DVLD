using DVLDBussinessLayer;
using DVLDDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet("{personId}")]
        public IActionResult GetUserMessages(int personId)
        {
            var messages = clsUserMessage.GetUserMessages(personId);
            return Ok(messages);
        }

        [HttpGet("unread-count/{personId}")]
        public IActionResult GetUnreadCount(int personId)
        {
            int count = clsUserMessage.GetUnreadCount(personId);
            return Ok(new { count });
        }

        [HttpPatch("read/{messageId}")]
        public IActionResult MarkAsRead(int messageId)
        {
            if (clsUserMessage.MarkAsRead(messageId))
                return Ok(new { success = true });
            
            return NotFound(new { message = "Message not found" });
        }

        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] UserMessageDTO request)
        {
            if (request == null || request.PersonID <= 0)
                return BadRequest(new { message = "Invalid request data" });

            // If SenderID is same as PersonID, it's a message FROM the user TO DVLD
            // In a real chat, we might have a specific RecipientID, but for now we use PersonID as the "Conversation Owner"
            bool success = clsUserMessage.SendChatMessage(
                request.PersonID, 
                request.SenderID ?? request.PersonID, 
                request.Title ?? "New Message", 
                request.Content, 
                request.MessageType ?? "Chat"
            );

            if (success)
                return Ok(new { success = true });

            return StatusCode(500, new { message = "Failed to send message" });
        }
    }
}
