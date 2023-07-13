using DatingSite.Data.Models;

namespace DatingSite.Data.Mocks
{
    public class MockMessages
    {
        static List<Chat> chats = new List<Chat>()
        {
            new Chat()
            {
                Id = Guid.NewGuid(),
                PersonId = Guid.NewGuid(), //число для теста
                Name = "Some name"
            }
        };
        //сюда добавить чат с каким-нибудь человечком
        static public List<Chat> Chats { get { return chats; } set { chats.AddRange(value); } }
    }
}