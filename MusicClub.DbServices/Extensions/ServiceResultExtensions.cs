using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices.Extensions
{
    internal static class ServiceResultExtensions
    {
        public static ServiceResult<T> Wrap<T>(this T? data, ServiceMessages? messages = null)
        {
            return new ServiceResult<T>
            {
                Data = data,
                Messages = data == null ? messages : null
            };
        }
    }
}