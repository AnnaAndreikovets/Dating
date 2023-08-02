using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.Data.Repository
{
    public class ChatRepository : IChat
    {
        readonly ApplicationDBContext context;
        readonly IPeople people;

        public ChatRepository(ApplicationDBContext context, IPeople people)
        {
            this.context = context;
            this.people = people;
        }
        
        public Chat? Chat(Guid? id) => Chats()?.FirstOrDefault(c => c.BlankId.CompareTo(id) == 0);

        public Chats? Chats(Guid id) => context.Chats.Include(c => c.UserChats).FirstOrDefault(c => c.UserId.CompareTo(id) == 0);

        public List<Chat>? Chats()
        {
            foreach(var i in context.Chats.Include(c => c.UserChats)) Console.WriteLine(people.User(i.UserId)?.Email + ": " + i.UserChats?.Count());
            return Chats(people.User().Id)?.UserChats;
        }

        public async Task DeleteChat(Guid userId, Guid blankId)
        {
            var userChats = Chats(userId)?.UserChats;
            
            if(userChats is not null)
            {
                Chat? chat = userChats?.FirstOrDefault(c => c.BlankId.CompareTo(blankId) == 0);

                if(chat is not null)
                {
                    userChats!.Remove(chat);
                    
                    await context.SaveChangesAsync();

                    return;
                }
            }

            throw new ArgumentNullException();
        }
    
        public async Task AddChatAndLike(Guid id1, Guid id2)
        {
            var anket = people.Anket(id1, id2);
            User? user1 = people.User(id1);
            User? user2 = people.User(id2);

            if(anket is null || user1 is null || user2 is null)
            {
                throw new ArgumentNullException("Invalid user id for user and/or anket!");
            }

            anket.Like = true;

            Chats? chats = Chats(id1);

            if(chats is null)
            {
                chats = new Chats()
                {
                    Id = Guid.NewGuid(),
                    UserId = id1
                };

                await context.Chats.AddAsync(chats);
            }

            if(chats.UserChats is null)
            {
                chats.UserChats = new List<Chat>();
            }
            
            Chat userChat = new Chat()
            {
                Id = new Guid(),
                BlankId = user2.BlankId,
                AnketId = anket.Id
            };

            await context.AddAsync(userChat);

            chats.UserChats.Add(userChat);

            await context.SaveChangesAsync();
        }
    }
}