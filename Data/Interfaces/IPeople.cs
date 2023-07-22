using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IPeople
    {
        public User? PersonForLooking();
        public User? PersonForWatching();
        public Blank? Blank(Guid id);
        public IEnumerable<Blank> Blanks();
        public Blank CurrentUser();
        public IEnumerable<User>? Users();
        public Interested? Interested(Guid userId);
        public Interaction? Interaction(Guid userId);
        public User User();
        public User? User(Guid id);
    }
}