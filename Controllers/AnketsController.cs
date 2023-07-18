using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    public class AnketsController : Controller
    {
        readonly IPeople people;
        readonly IChat chat;

        public AnketsController(IPeople blank, IChat chat)
        {
            this.people = blank;
            this.chat = chat;
        }

        [Route("Ankets/List")]
        public IActionResult Index()
        {
            Blank? blank = people.PersonForLooking();
            
            if(blank is null)
            {
                return View(null);
            }
            
            AnketViewModel anketViewModel = new AnketViewModel()
            {
                Blank = blank,
                Anket = people.Anket(blank.Id)
            };
            
            return View(anketViewModel);
        }

        [Route("Ankets/Skip/{guid}")]
        [Route("Ankets/Skip/{guid}/{like}")]
        public IActionResult Skip(Guid guid, bool like)
        {
            Blank? blank = people.Person(guid);
            
            if(blank is not null)
            {
                Anket? anket = people.Anket(blank.Id);

                if(anket is not null)
                {
                    if(like)
                    {
                        /*Chat _chat = new Chat()
                        {
                            Id = Guid.NewGuid(),
                            Blank = blank
                        };

                        chat.AddChat(_chat);
                
                        anket.Like = true;
                        blank.ChatId = _chat.Id;*/
                        Like attraction = new Like()
                        {
                            Id = Guid.NewGuid(),
                            UserId = guid,
                            //UsersId =
                        };
                    }

                    anket.See = true;
                }
            }

            return RedirectToAction("Index");
        }
    }
}