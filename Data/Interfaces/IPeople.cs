using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IPeople
    {
        public User? PersonForLooking();
        public User? PersonForWatching();
        public Blank? Blank(Guid id);
        public IEnumerable<Blank>? Blanks();
        public Blank CurrentUser();
        public IEnumerable<User>? Users();
        public Interested? Interested(Guid userId);
        public Interaction? Interaction(Guid userId);
        public User User();
        public User? User(Guid id);
        public User? User(string email);
        public User? User(string email, string password);
        public Task AddUser(User user);
        public void SetUser(User user);
        public Task AddInteractions(Interaction interaction);
        public Task AddInterested(Interested interested);
        public Task AddBlank(Blank blank);
        public Task AddAnket(Interaction interaction, Guid id);
        public Task AddInterested(Interested interested, Guid id, Guid userId);
        public Anket? Anket(Guid id);
        public Anket? Anket(Guid userId, Guid secondId);
        public Task RemoveInterestedUser(Guid id);
    }
}