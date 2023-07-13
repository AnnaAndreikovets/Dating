using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class ChatRepository : IChat
    {
        public Chat? Chat(Guid id)
        {
            return MockMessages.Chats.FirstOrDefault(c => c.Id.CompareTo(id) == 0);
        }

        public IEnumerable<Chat>? Chats()
        {
            return MockMessages.Chats;
        }
    }
}