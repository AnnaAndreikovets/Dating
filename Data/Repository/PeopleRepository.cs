using System.Linq;
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
                var result = Users()?.FirstOrDefault(u => 
                    {
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
                return Users()?.FirstOrDefault(u => u.Id.CompareTo(id) == 0);
            }

            return null;
        }

        public Blank? Blank(Guid id)
        {
            return MockPeople.Blanks.FirstOrDefault(b => b.Id.CompareTo(id) == 0);
        }

        public IEnumerable<Blank> Blanks()
        {
            return MockPeople.Blanks;
        }
        
        public Blank CurrentUser()
        {
            return Blank(MockPeople.User.BlankId)!;
        }

        public IEnumerable<User>? Users()
        {
            return MockPeople.Users;
        }

        public Interested? Interested(Guid userId)
        {
            return MockPeople.Interesteds?.FirstOrDefault(i => i.UserId.CompareTo(userId) == 0);
        }

        public Interaction? Interaction(Guid userId)
        {
            return MockPeople.Interactions.FirstOrDefault(a => a.UserId.CompareTo(userId) == 0);
        }

        public User User()
        {
            return MockPeople.User;
        }
    }
}