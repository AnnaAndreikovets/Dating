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
            /*IEnumerable<Chat>? chats = chat.Chats()?.OrderByDescending(c => c.Messages is not null ? c.Messages.Last().Time : DateTime.Now);
            
            IEnumerable<Blank>? blanks = people.Blanks().Where(p => chats.Any(c => c.BlankId == p.Id));

            ChatsViewModel chatsViewModel = new ChatsViewModel()
            {
                Chats = chats,
                Blanks = blanks
            };

            return View(chatsViewModel);*/

            IEnumerable<Chat>? chats = chat.Chats()?.OrderByDescending(c => c.Messages is not null ? c.Messages.Last().Time : DateTime.Now);
            
            IEnumerable<Blank>? blanks = people.Blanks().Where(p => chats.Any(c => c.BlankId == p.Id));

            //List<Tuple<Chat, Blank>> result = chats.Join(blanks, c => c.Id, b => b.ChatId, (c, b) => Tuple.Create(c, b)).ToList();
            List<Tuple<Chat, Blank>> result = blanks.Join(chats, b => b.Id, c => c.BlankId, (c, b) => Tuple.Create(b, c)).ToList();

            ChatsViewModel chatsViewModel = new ChatsViewModel()
            {
                ChatsBlanks = result
            };

            return View(chatsViewModel);
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