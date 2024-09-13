using System.Net;

namespace MusicClub.Dto.Enums
{
    public enum ErrorCode
    { 
        //Database errors
        NotFound = 600,
        Referenced = 601,
        NotCreated = 602,
        NotDeleted = 603,
        NotUpdated = 604,

        //API errors
        FetchError = 701
    }
}
