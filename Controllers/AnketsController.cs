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
            Guid userId = people.User().Id;
            Interaction? attractionUser = people.Interaction(userId);
            Interaction? attractionUser2 = people.Interaction(id);
            Interested? interested = people.Interested(id);

            if(attractionUser is null || attractionUser2 is null || interested is null)
            {
                throw new ArgumentNullException("Invalid user id for interaction and/or interested!");
            }

            void AddAnket(Guid id, Interaction interaction)
            {
                var ankets = interaction.UsersAnkets;

                if(ankets is null)
                {
                    ankets = new List<Anket>();
                }

                ankets.Add(new Anket()
                {
                    Id = Guid.NewGuid(),
                    UserId = id,
                });
            }

            AddAnket(id, attractionUser);
            AddAnket(userId, attractionUser2);

            if(like)
            {
                var users = interested.Users;

                if(users is null)
                {
                    users = new List<Guid>();
                }
                
                users.Add(userId);
            }

            return RedirectToAction("Index");
        }
    }
}