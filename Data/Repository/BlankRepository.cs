using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class BlankRepository : IBlank
    {
        public Blank? PersonForLooking(string sex)
        {
            return MockBlanks.Blanks.FirstOrDefault(b => b.Sex == sex & b.See == false);
        }

        public Blank? Person(Guid id)
        {
            return MockBlanks.Blanks.FirstOrDefault(b => b.Id.CompareTo(id) == 0);
        }
    }
}