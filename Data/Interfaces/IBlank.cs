using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IBlank
    {
        public IEnumerable<Blank> PersonForLooking(string sex);
        public IEnumerable<Blank> Favourite();
        public Blank? Person(Guid id);
    }
}