using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    //[Authorize]
    public class AnketsController : Controller
    {
        readonly IPeople people;

        public AnketsController(IPeople blank)
        {
            this.people = blank;
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

        [Route("Ankets/Skip")]
        public IActionResult Skip(Guid id, bool like)
        {
            //выполрнить логику по выполнению данных только если все данные правильные
            Guid userId = people.User().Id;
            
            Interaction? attractionUser = people.Interaction(userId);
            Interaction? attractionUser2 = people.Interaction(id);

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