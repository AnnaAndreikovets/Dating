using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class PeopleRepository : IPeople
    {
        public User? PersonForLooking()
        {
            var user = User();
            var attraction = Interaction(user.Id);

            if(attraction is not null)
            {
                var result = Users()?.FirstOrDefault(u => {
                        Blank blank = Blank(u.BlankId)!;
                        Blank userBlank = Blank(user.BlankId)!;

                        return (!attraction.UsersAnkets?.Any(a => a.UserId.CompareTo(u.Id) == 0) ?? true) && blank.Sex == userBlank.PreferSex && blank.PreferSex == userBlank.Sex;
                    }
                );

                return result;
            }

            return null;
        }

        public User? PersonForWatching()
        {
            var users = Interested(User().Id)?.Users;
            
            if(users?.Count() > 0)
            {
                var id = users.First();
                
                return User(id);
            }

            return null;
        }

        public Blank? Blank(Guid id)
        {
            var blanks = Blanks();

            if(blanks is null)
            {
                throw new NullReferenceException("Blanks are empty!");
            }

            return blanks.FirstOrDefault(b => b.Id.CompareTo(id) == 0);
        }

        public IEnumerable<Blank>? Blanks() => MockPeople.Blanks;
        
        public Blank CurrentUser() => Blank(User().BlankId)!;

        public IEnumerable<User>? Users() => MockPeople.Users;

        public Interested? Interested(Guid userId) => MockPeople.Interesteds?.FirstOrDefault(i => i.UserId.CompareTo(userId) == 0);

        public Interaction? Interaction(Guid userId) => MockPeople.Interactions.FirstOrDefault(a => a.UserId.CompareTo(userId) == 0);

        public User User() => MockPeople.User;
    
        public User? User(Guid id) => Users()?.FirstOrDefault(u => u.Id.CompareTo(id) == 0);
    
        public void AddUser(User user)
        {
            SetUser(user);

            MockPeople.Users.Add(user);
        }

        public void SetUser(User user) => MockPeople.User = user;

        public void AddInteractions(Interaction interaction) => MockPeople.Interactions.Add(interaction);
        
        public void AddInterested(Interested interested) => MockPeople.Interesteds.Add(interested);
        
        public void AddBlank(Blank blank) => MockPeople.Blanks.Add(blank);
        
        public void AddAnket(Interaction interaction, Guid id)
        {
            if(interaction.UsersAnkets is null)
            {
                interaction.UsersAnkets = new List<Anket>();
            }

            Anket anket = new Anket()
            {
                Id = Guid.NewGuid(),
                UserId = id
            };

            interaction.UsersAnkets.Add(anket);

        }

        public void AddInterested(Interested interested, Guid id, Guid userId)
        {
            if(interested.Users is null)
            {
                interested.Users = new List<Guid>();
            }
                
            interested.Users.Add(userId);
        }

        public Anket? Anket(Guid id) => Interaction(User().Id)?.UsersAnkets?.FirstOrDefault(a => a.Id.CompareTo(id) == 0);

        public Anket? Anket(Guid userId, Guid secondId) => Interaction(userId)?.UsersAnkets?.FirstOrDefault(a => a.UserId == secondId);
    }
}