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
            Console.WriteLine(_blank.ChatId);
            Chat _chat = chat.Chat(_blank.ChatId);
            Console.WriteLine(_chat + " -c");

            return View(_chat);
        }
    }
}