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
            IEnumerable<Chat> chats = chatRepository.Chats();
            //если вдруг там пусто,то вернуть сообщение, а иначе списокs
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