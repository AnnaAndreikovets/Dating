using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IPeople
    {
        public Blank? PersonForLooking();
        public Blank? Person(Guid id);
        public IEnumerable<Blank> Blanks();
        public Blank User();
        public Anket? Anket(Guid id);
    }
}