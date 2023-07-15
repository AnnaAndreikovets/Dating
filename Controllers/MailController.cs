using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Repository;
using DatingSite.Data.Models;
using DatingSite.Data.Interfaces;

namespace DatingSite.Controllers
{
    public class MailController : Controller
    {
        readonly IChat chat;
        readonly IBlank blank;

        public MailController(IChat chat, IBlank blank)
        {
            this.chat = chat;
            this.blank = blank;
        }

        [Route("Mail/List")]
        public IActionResult List()
        {
            IEnumerable<Chat> chats = chat.Chats().OrderByDescending(c => c.Messages is not null ? c.Messages.Last().Time : DateTime.Now);
            
            return View(chats);
        }

        [Route("Mail/Chat/{id}")]
        public IActionResult Chat(Guid id)
        {
            //vm
            Blank _blank = blank.Person(id);
            
            Chat _chat = chat.Chat(_blank.ChatId);

            return View(_chat);
        }
    
        [HttpPost]
        [Route("/Mail/Message/{id}")]
        public void Message(Guid id)
        {
            Chat currentChat = chat.Chat(id);
            Blank user = blank.User();

            Message _message = new Message()
            {
                Text = Request.Form["message"],
                Time = DateTime.Now,
                Sender = $"{user.FirstName} {user.SecondName}"
            };
            
            if(currentChat.Messages is null)
            {
                _message.Id = 1;

                currentChat.Messages = new List<Message>()
                {
                    _message
                };
            }
            else
            {
                _message.Id = currentChat.Messages.Last().Id + 1;

                currentChat.Messages.Add(_message);
            }
            //вернуть инфу про успешное сообщение
            
        }
    }
}