using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class PeopleRepository : IPeople
    {
        public Blank? PersonForLooking()
        {
            return MockPeople.Blanks.FirstOrDefault(b => b.Sex == User().PreferSex && b.PreferSex == User().Sex && Anket(b.Id)?.See == false);
        }

        public Blank? Person(Guid id)
        {
            return MockPeople.Blanks.FirstOrDefault(b => b.Id.CompareTo(id) == 0);
        }

        public IEnumerable<Blank> Blanks()
        {
            return MockPeople.Blanks;
        }
        
        public Blank User()
        {
            return MockPeople.User;
        }

        public Anket? Anket(Guid id)
        {
            return MockPeople.Ankets.FirstOrDefault(a => a.BlankId == id);
        }
    }
}