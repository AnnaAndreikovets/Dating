using DatingSite.Data.Mocks;
using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IChat
    {
        public Chat? Chat(Guid id);
        public IEnumerable<Chat>? Chats();
    }
}