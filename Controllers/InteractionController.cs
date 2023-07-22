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
            void LikeAndAddChat(Guid id1, Guid id2)
            {
                var anket = people.Interaction(id1)?.UsersAnkets?.FirstOrDefault(a => a.UserId == id2);

                if(anket is null)
                {
                    throw new Exception();
                }

                anket.Like = true;

                User? user1 = people.User(id1);
                User? user2 = people.User(id2);

                if(user1 is null || user2 is null)
                {
                    throw new Exception();
                }

                Chats? chats = chat.Chats(id1);

                if(chats is null)
                {
                    chats = new Chats()
                    {
                        Id = Guid.NewGuid(),
                        UserId = id1
                    };
                }
                
                var userChats = chats.UserChats;

                if(userChats is null)
                {
                    userChats = new List<Chat>();
                }

                Chat userChat = new Chat()
                {
                    Id = new Guid(),
                    BlankId = user2.BlankId
                };

                userChats.Add(userChat);
            }

            var userId = people.User().Id;

            LikeAndAddChat(id, userId);
            LikeAndAddChat(userId, id);

            return RedirectToAction("Dislike", new {id = id});
        }
    }
}