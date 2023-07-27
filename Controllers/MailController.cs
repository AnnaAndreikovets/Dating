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
            
                if(blanks is not null)
                {
                    List<Tuple<Chat, Blank>> result = blanks.Join(userChat, b => b.Id, c => c.BlankId, (c, b) => Tuple.Create(b, c)).ToList();

                    ChatsViewModel chatsViewModel = new ChatsViewModel()
                    {
                        ChatsBlanks = result
                    };

                    return View(chatsViewModel);
                }
            }

            return View();
        }

        [Route("Mail/Chat")]
        public IActionResult Chat(Guid id)
        {
            Blank? blank = people.Blank(id);

            if(blank is null)
            {
                throw new ArgumentNullException("Invalid user id for blank!");
            }
            
            Chat? _chat = chat.Chat(blank.Id);

            if(_chat is null)
            {
                throw new ArgumentNullException("Invalid user id for chat!");
            }

            ChatViewModel chatViewModel = new ChatViewModel()
            {
                Chat = _chat,
                Blank = blank
            };

            return View(chatViewModel);
        }
    
        [HttpPost]
        [Route("/Mail/Message")]
        public void Message(Guid id)
        {
            Chat? currentChat = chat.Chat(id);

            if(currentChat is null)
            {
                throw new ArgumentNullException("Invalid id for chat!");
            }

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

                var messages = currentChat.Messages;
                var messageId = _message.Id;

                if(messages is null)
                {
                    messageId = 1;

                    messages = new List<Message>()
                    {
                        _message
                    };
                }
                else
                {
                    messageId = messages.Last().Id + 1;

                    messages.Add(_message);
                }
            }
        }
        
        [Route("Mail/DeleteChat")]
        public IActionResult DeleteChat(Guid blankId, Guid anketId)
        {
            User? user = people.User();
            
            if(user is null)
            {
                throw new ArgumentNullException("Invalid id for user!");
            }

            Blank? blank1 = people.Blank(user.BlankId);
            Blank? blank2 = people.Blank(blankId);

            if(blank1 is null || blank2 is null)
            {
                throw new ArgumentNullException("Invalid id for blank!");
            }

            Anket? anket2 = people.Anket(anketId);

            if(anket2 is null)
            {
                throw new ArgumentNullException("Invalid id for anket!");
            }

            Anket? anket1 = people.Anket(user.Id, anket2.UserId);

            if(anket1 is null)
            {
                throw new ArgumentNullException("Invalid id for user's anket!");
            }

            anket1.Like = false;
            anket2.Like = false;
        
            chat.DeleteChat(user.Id, blank2.Id);
            chat.DeleteChat(anket2.UserId, blank1.Id);
            
            return RedirectToAction("List", "Mail");
        }
    }
}