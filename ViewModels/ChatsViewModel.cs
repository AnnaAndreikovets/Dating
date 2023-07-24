using DatingSite.Data.Models;

namespace DatingSite.ViewModels
{
    public class ChatsViewModel
    {
        public List<Tuple<Chat, Blank>> ChatsBlanks { get; set; } = null!;
    }
}