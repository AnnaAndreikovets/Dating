using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Repository;
using DatingSite.Data.Models;
using DatingSite.Data.Interfaces;

namespace DatingSite.Controllers
{
    public class MailController : Controller
    {
        readonly IChat chatRepository;

        public MailController(IChat chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        [Route("Mail/List")]
        public IActionResult List()
        {
            IEnumerable<Chat> chats = chatRepository.Chats().OrderByDescending(c => c.Messages is not null ? c.Messages.Last().Time : DateTime.Now);
            
            return View(chats);
        }

        [Route("Mail/Chat/{id}")]
        public IActionResult Chat(Guid id)
        {
            //vm
            Chat chat = chatRepository.Chat(id);

            return View(chat);
        }
    }
}