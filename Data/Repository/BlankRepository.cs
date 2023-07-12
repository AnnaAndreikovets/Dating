using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class BlankRepository : IBlank
    {
        public IEnumerable<Blank> PersonForLooking(string sex)
        {
            return MockBlanks.Blanks.Where(b => b.Sex == sex & b.See == false);
        }

        public IEnumerable<Blank> Favourite()
        {
            return MockBlanks.Blanks.Where(b => b.Like);
        }

        public Blank? Person(Guid id)
        {
            return MockBlanks.Blanks.FirstOrDefault(b => b.Id.CompareTo(id) == 0);
        }
    }
}