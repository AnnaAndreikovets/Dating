using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Models;
using DatingSite.Data.Interfaces;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    public class MailController : Controller
    {
        readonly IChat chat;
        readonly IPeople people;

        public MailController(IChat chat, IPeople people)
        {
            this.chat = chat;
            this.people = people;
        }

        [Route("Mail/List")]
        public IActionResult List()
        {
            IEnumerable<Chat> chats = chat.Chats().OrderByDescending(c => c.Messages is not null ? c.Messages.Last().Time : DateTime.Now);
            
            ChatsViewModel chatsViewModel = new ChatsViewModel()
            {
                Chats = chats
            };

            return View(chatsViewModel);
        }

        [Route("Mail/Chat/{id}")]
        public IActionResult Chat(Guid id)
        {
            //vm
            Blank blank = people.Person(id);
            
            Chat _chat = chat.Chat(blank.ChatId);

            ChatViewModel chatViewModel = new ChatViewModel()
            {
                Chat = _chat
            };

            return View(chatViewModel);
        }
    
        [HttpPost]
        [Route("/Mail/Message/{id}")]
        public void Message(Guid id)
        {
            Chat currentChat = chat.Chat(id);
            Blank user = people.User();

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