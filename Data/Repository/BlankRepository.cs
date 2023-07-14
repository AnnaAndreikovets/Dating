using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class BlankRepository : IBlank
    {
        public Blank? PersonForLooking()
        {
            return MockBlanks.Blanks.FirstOrDefault(b => b.Sex == User().PreferSex && b.See == false);
        }

        public Blank? Person(Guid id)
        {
            return MockBlanks.Blanks.FirstOrDefault(b => b.Id.CompareTo(id) == 0);
        }
        
        public Blank User()
        {
            return MockBlanks.User;
        }
    }
}