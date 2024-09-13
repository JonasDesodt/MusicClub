using MusicClub.DbCore.Models;

namespace MusicClub.DbCore.Interfaces
{
    public interface IPerson
    {
        int PersonId { get; set; }

        Person? Person { get; set; }
    }
}
