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

        public async Task<IActionResult> Skip(Guid id, bool like)
        {
            Guid userId = people.User().Id;
            Interaction? interactionUser = people.Interaction(userId);
            Interaction? interactionUser2 = people.Interaction(id);
            Interested? interested = people.Interested(id);
            
            if(interactionUser is null || interactionUser2 is null || interested is null)
            {
                throw new ArgumentNullException("Invalid user id for interaction and/or interested!");
            }

            await people.AddAnket(interactionUser, id);
            await people.AddAnket(interactionUser2, userId);

            if(like)
            {
                await people.AddInterested(interested, id, userId);
            }

            return RedirectToAction("Index");
        }
    }
}