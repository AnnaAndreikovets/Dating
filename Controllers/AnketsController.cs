using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data;

namespace DatingSite.Controllers
{
    public class AnketsController : Controller
    {
        readonly IBlank blank;
        readonly IChat chat;

        public AnketsController(IBlank blank, IChat chat)
        {
            this.blank = blank;
            this.chat = chat;
        }

        [Route("Ankets/List")]
        public IActionResult Index()
        {
            //vm
            Blank result = blank.PersonForLooking();
            
            return View(result);
        }

        [Route("Ankets/Skip/{guid}")]
        [Route("Ankets/Skip/{guid}/{like}")]
        public IActionResult Skip(Guid guid, bool like)
        {
            Blank? _blank = blank.Person(guid); //проверка, что айди верное
            
            
            if(like)
            {
                Chat _chat = new Chat()
                {
                    Id = Guid.NewGuid(),
                    Blank = _blank
                };

                chat.AddChat(_chat);
                
                _blank.Like = true;
                _blank.ChatId = _chat.Id;
            }

            _blank.See = true;
            
            return RedirectToAction("Index", new {_blank.Sex});
        }
    }
}