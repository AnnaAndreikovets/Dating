using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IBlank
    {
        public Blank? PersonForLooking(string sex);
        public Blank? Person(Guid id);
    }
}