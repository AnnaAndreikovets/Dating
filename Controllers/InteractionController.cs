using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.ViewModels;

namespace DatingSite.Controllers
{
    //[Authorize]
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
        }

        [Route("Interaction/Dislike")]
        public IActionResult Dislike(Guid id)
        {
            var users = people?.Interested(people.User().Id)?.Users;

            if(users is null)
            {
                throw new ArgumentNullException("Invalid user data!");
            }

            users.Remove(id);
            
            return RedirectToAction("Index");
        }
        
        [Route("Interaction/Like")]
        public IActionResult Like(Guid id)
        {
            void LikeAndAddChat(Guid id1, Guid id2)
            {
                var anket = people.Anket(id1, id2);
                User? user1 = people.User(id1);
                User? user2 = people.User(id2);

                if(anket is null || user1 is null || user2 is null)
                {
                    throw new ArgumentNullException("Invalid user id for user and/or anket!");
                }

                anket.Like = true;

                Chats? chats = chat.Chats(id1);

                if(chats is null)
                {
                    chats = new Chats()
                    {
                        Id = Guid.NewGuid(),
                        UserId = id1
                    };

                    chat.AddChats(chats);
                }

                var userChats = chats.UserChats;

                if(userChats is null)
                {
                    userChats = new List<Chat>();
                    
                    chat.AddListChats(userChats, id1);
                }
                
                Chat userChat = new Chat()
                {
                    Id = new Guid(),
                    BlankId = user2.BlankId,
                    AnketId = anket.Id
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