using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using MusicClub.Api.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MusicClub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleOAuthController(IConfiguration configuration, IHttpClientFactory httpClientFactory) : Controller
    {
        // Redirect to Google OAuth 2.0 login
        [HttpGet("login")]
        public IActionResult Login()
        {
            var clientId = configuration["GoogleOAuth:ClientId"];
            var redirectUri = configuration["GoogleOAuth:RedirectUri"];
            var scope = "https://www.googleapis.com/auth/calendar";
            var authUrl = $"https://accounts.google.com/o/oauth2/v2/auth?client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope={scope}&access_type=offline&prompt=consent";

            return Redirect(authUrl);
        }

        // Handle the callback from Google
        [HttpGet("callback")]
        public async Task<IActionResult> Callback(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Authorization code not provided.");
            }

            var token = await ExchangeCodeForTokenAsync(code);


            var httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var newEvent = new CalendarEvent
            {
                Summary = "Meeting with Bob " + Guid.NewGuid().ToString(),
                Location = "123 Main St, City, Country",
                Description = "Discussing project updates.",
                Start = new EventDateTime
                {
                    DateTime = "2024-10-18T10:00:00-07:00",
                    TimeZone = "America/Los_Angeles"
                },
                End = new EventDateTime
                {
                    DateTime = "2024-10-18T11:00:00-07:00",
                    TimeZone = "America/Los_Angeles"
                },
                Attendees =
                    [
                        new Attendee { Email = "bob@example.com" }
                    ]
            };


            var response = await httpClient.PostAsJsonAsync("https://www.googleapis.com/calendar/v3/calendars/primary/events", newEvent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                //return responseBody;  // The event was created successfully, return the event details
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error posting event: {error}");
            }



            // Send the token back to the client (Blazor WebAssembly)
            return Ok(new { access_token = token });
        }

        // Exchange the authorization code for an access token
        private async Task<string> ExchangeCodeForTokenAsync(string code)
        {
            var clientId = configuration["GoogleOAuth:ClientId"];
            var clientSecret = configuration["GoogleOAuth:ClientSecret"];
            var redirectUri = configuration["GoogleOAuth:RedirectUri"];
            var tokenEndpoint = configuration["GoogleOAuth:TokenEndpoint"];

            //if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret) || string.IsNullOrWhiteSpace(redirectUri) || string.IsNullOrWhiteSpace(tokenEndpoint))
            //{
            //}

            var httpClient = httpClientFactory.CreateClient();

            var tokenRequestData = new FormUrlEncodedContent(
            [
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("redirect_uri", redirectUri),
            new KeyValuePair<string, string>("grant_type", "authorization_code")
            ]);

            var response = await httpClient.PostAsync(tokenEndpoint, tokenRequestData);
            response.EnsureSuccessStatusCode();


            var content = await response.Content.ReadFromJsonAsync<GoogleOAuthTokenResponse>();

            return content.AccessToken;
        }
    }
}
