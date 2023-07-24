using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Models;
using DatingSite.Data.Interfaces;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    //[Authorize]
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
            IEnumerable<Chat>? userChat = chat.Chats()?.OrderByDescending(c => c.Messages is not null ? c.Messages.Last().Time : DateTime.Now);
            
            if(userChat is not null)
            {
                IEnumerable<Blank>? blanks = people.Blanks().Where(p => userChat.Any(c => c.BlankId == p.Id));
            
                List<Tuple<Chat, Blank>> result = blanks.Join(userChat, b => b.Id, c => c.BlankId, (c, b) => Tuple.Create(b, c)).ToList();

                ChatsViewModel chatsViewModel = new ChatsViewModel()
                {
                    ChatsBlanks = result
                };

                return View(chatsViewModel);
            }

            return View();
        }

        [Route("Mail/Chat/{id}")]
        public IActionResult Chat(Guid id)
        {
            /*Blank? blank = people.Blank(id);
            
            Chat _chat = chat.Chat(blank.ChatId);

            ChatViewModel chatViewModel = new ChatViewModel()
            {
                Chat = _chat
            };

            return View(chatViewModel);*/
            throw new NotImplementedException();
        }
    
        [HttpPost]
        [Route("/Mail/Message/{id}")]
        public void Message(Guid id)
        {
            /*Chat currentChat = chat.Chat(id);
            Blank user = people.CurrentUser();

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
            */
            throw new NotImplementedException();
        }
    }
}