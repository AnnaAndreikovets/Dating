using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    [Authorize]
    public class AnketsController : Controller
    {
        readonly IPeople people;

        public AnketsController(IPeople blank)
        {
            this.people = blank;
        }

        public IActionResult Index()
        {
Console.WriteLine("-----------------------");
            User? user = people.PersonForLooking();
            
            if(user is null)
            {
Console.WriteLine("null1");
                return View(null);
            }
            
            Blank? blank = people.Blank(user.BlankId);
Console.WriteLine("1");
            if(blank is null)
            {
Console.WriteLine("null2");
                return View(null);
            }
            
            BlankViewModel anketViewModel = new BlankViewModel()
            {
                Blank = blank,
                User = user
            };
Console.WriteLine("2 --------------------------");
            return View(anketViewModel);
        }

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
Console.WriteLine("start");
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