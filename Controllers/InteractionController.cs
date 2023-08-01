using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    [Authorize]
    public class InteractionController : Controller
    {
        readonly IPeople people;
        readonly IChat chat;
        
        public InteractionController(IPeople people, IChat chat)
        {
            this.people = people;
            this.chat = chat;
        }

        public IActionResult Index()
        {
            User? user = people.PersonForWatching();
         
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

        public async Task<IActionResult> Dislike(Guid id)
        {
            await people.RemoveInterestedUser(id);
            
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Like(Guid id)
        {
            var userId = people.User().Id;

            await chat.AddChatAndLike(id, userId);
            await chat.AddChatAndLike(userId, id);

            return RedirectToAction("Dislike", new {id = id});
        }
    }
}