using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IBlank
    {
        public Blank? PersonForLooking();
        public Blank? Person(Guid id);
        public Blank User();
    }
}