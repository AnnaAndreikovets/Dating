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
            Blank? blank = people.Blank(id);
            
            Chat? _chat = chat.Chat(blank.Id);

            ChatViewModel chatViewModel = new ChatViewModel()
            {
                Chat = _chat,
                Blank = blank
            };

            return View(chatViewModel);
        }
    
        [HttpPost]
        [Route("/Mail/Message/{id}")]
        public void Message(Guid id)
        {
            Chat? currentChat = chat.Chat(id);

            if(currentChat is not null)
            {
                Blank user = people.CurrentUser();
                string message = Request.Form["msg"].ToString().Trim();

                if(!string.IsNullOrEmpty(message))
                {
                    Message _message = new Message()
                    {
                        Text = message,
                        Time = DateTime.Now,
                        //Sender = $"{user.FirstName} {user.SecondName}"
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
                }
            }
        }
        
        [Route("Mail/DeleteChat/{blankId}/{anketId}")]
        public IActionResult DeleteChat(Guid blankId, Guid anketId)
        {
            User? user = people.User();

            Blank? blank1 = people.Blank(user.BlankId);
            Blank? blank2 = people.Blank(blankId);

            Anket? anket2 = people.Anket(anketId);
            Anket? anket1 = people.Anket(user.Id, anket2.UserId);

            anket1.Like = false;
            anket2.Like = false;
        
            chat.DeleteChat(user.Id, blank2.Id);
            chat.DeleteChat(anket2.UserId, blank1.Id);
            
            return RedirectToAction("List", "Mail");
        }
    }
}