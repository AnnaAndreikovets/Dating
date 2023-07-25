using DatingSite.Data.Models;

namespace DatingSite.Data.Mocks
{
    public static class MockMessages
    {
        static List<Chats> chats = new List<Chats>()
        {
            /*new Chats()
            {
                Id = Guid.NewGuid(),
                UserId = MockPeople.User.Id,
                UserChats = new List<Chat>()
                {
                    new Chat()
                    {
                        Id = Guid.NewGuid(),
                        BlankId = MockPeople.Blanks[0].Id,
                        Messages = new List<Message>()
                        {
                            new Message()
                            {
                                Id = 1,
                                Text = "Hellow!",
                                Time = DateTime.Now,
                                Sender = MockPeople.Blanks[0].FirstName
                            }
                        }
                    }
                }
            }*/
        };
        
        static public List<Chats> Chats { get { return chats; } set { chats.AddRange(value); } }
    }
}