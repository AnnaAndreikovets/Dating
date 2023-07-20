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
            User? user = people.PersonForLooking();
            
            if(user is null)
            {
                return View(null);
            }
            
            Blank? blank = people.Blank(user.BlankId);

            if(blank is null)
            {
                return View(null);
            }
            
            BlankViewModel anketViewModel = new BlankViewModel()
            {
                Blank = blank,
                User = user
            };
            
            return View(anketViewModel);
        }

        [Route("Ankets/Skip/{id}")]
        [Route("Ankets/Skip/{id}/{like}")]
        public IActionResult Skip(Guid id, bool like)
        {
            //выполрнить логику по выполнению данных только если все данные правильные
            Guid userId = people.User().Id;
            
            Attraction? attractionUser = people.Attraction(userId);
            Attraction? attractionUser2 = people.Attraction(id);

            if(attractionUser is null || attractionUser2 is null)
            {
                throw new ArgumentException();
            }

            if(attractionUser.UsersAnkets is null)
            {
                attractionUser.UsersAnkets = new List<Anket>();
            }

            if(attractionUser2.UsersAnkets is null)
            {
                attractionUser2.UsersAnkets = new List<Anket>();
            }

            attractionUser.UsersAnkets.Add(new Anket()
            {
                Id = Guid.NewGuid(),
                UserId = id,
            });
            attractionUser2.UsersAnkets.Add(new Anket()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
            });

            if(like)
            {
                Interested? interested = people.Interested(id);

                if(interested is null)
                {
                    throw new ArgumentException();
                }

                if(interested.Users is null)
                {
                    interested.Users = new List<Guid>();
                }
                
                interested.Users.Add(userId);
            }

            return RedirectToAction("Index");
        }
    }
}