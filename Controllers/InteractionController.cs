using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    public class InteractionController : Controller
    {
        readonly IPeople people;
        readonly IChat chat;
        
        public InteractionController(IPeople people, IChat chat)
        {
            this.people = people;
            this.chat = chat;
        }

        [Route("Interaction/Index")]
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
            /*User? user = people.PersonForLooking();
            
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
            
            return View(anketViewModel);*/
            //вернуть vm
        }

        [Route("Interaction/Dislike/{id}")]
        public IActionResult Dislike(Guid id)
        {
            var users = people?.Interested(people.User().Id)?.Users?.Remove(id);
            
            return RedirectToAction("Index");
        }
        
        [Route("Interaction/Like/{id}")]
        public IActionResult Like(Guid id)
        {
            void Delete(Guid id1, Guid id2)
            {
                var anket = people.Interaction(id1)?.UsersAnkets?.FirstOrDefault(a => a.UserId == id2);

                if(anket is not null)
                {
                    anket.See = true;
                }

                //так же тут надо добавить чат
            }

            var userId = people.User().Id;

            Delete(id, userId);
            Delete(userId, id);

            return Dislike(id);
        }
    }
}