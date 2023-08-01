using System.Linq;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.Data.Repository
{
    public class ChatRepository : IChat
    {
        
        public ApplicationDBContext context { get; set; }

        public ChatRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        
        public Chat? Chat(Guid? id) => Chats()?.FirstOrDefault(c => c.BlankId.CompareTo(id) == 0);

        public Chats? Chats(Guid id) => AllChats().FirstOrDefault(c => c.UserId.CompareTo(id) == 0);

        public List<Chat>? Chats() => Chats(ApplicationDBContext.User.Id)?.UserChats;

        public void AddChats(Chats chats) => AllChats().Add(chats);

        public void AddListChats(List<Chat> chats, Guid userId)
        {
            Chats? chats_ = Chats(userId);

            if(chats_ is null)
            {
                throw new ArgumentNullException("Invalid id for chats");
            }

            if(chats_.UserChats is null)
            {
                chats_!.UserChats = chats;
            }
        }

        public void DeleteChat(Guid userId, Guid blankId)
        {
            var userChats = Chats(userId)?.UserChats;
            
            if(userChats is not null)
            {
                Chat? chat = userChats?.FirstOrDefault(c => c.BlankId.CompareTo(blankId) == 0);

                if(chat is not null)
                {
                    userChats!.Remove(chat);
                    
                    return;
                }
            }

            throw new ArgumentNullException();
        }
    
        List<Chats> AllChats() => context.Chats.Include(c => c.UserChats).ToList();
    }
}