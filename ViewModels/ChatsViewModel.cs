using DatingSite.Data.Models;

namespace DatingSite.ViewModels
{
    public class ChatsViewModel
    {
        /*public IEnumerable<Chat>? Chats { get; set; }
        public IEnumerable<Blank>? Blanks { get; set; }*/
        public List<Tuple<Chat, Blank>> ChatsBlanks { get; set; } = null!;
    }
}