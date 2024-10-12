namespace MusicClub.ApiServices.Helpers
{
    internal static class TryCatchHttpRequestHelpers
    {
        public static async Task<HttpResponseMessage?> HandleHttpRequestExceptions(Func<Task<HttpResponseMessage>> httpRequest)
        {
            HttpResponseMessage? httpResponseMessage;

            try
            {
                httpResponseMessage = await httpRequest.Invoke();
            }
            catch (Exception ex)
            {
                switch (ex)
                {   
                    //TODO: logs exceptions, rethrow if not expected
                    
                    default:
                        return null;
                }
            }

            return httpResponseMessage;
        }
    }
}
