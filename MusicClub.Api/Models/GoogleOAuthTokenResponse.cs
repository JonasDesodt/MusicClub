using System.Text.Json.Serialization;

namespace MusicClub.Api.Models
{
    public class GoogleOAuthTokenResponse
    {
        // The OAuth 2.0 access token for making authorized requests
        [JsonPropertyName("access_token")]
        public required string AccessToken { get; set; }

        // The type of the token, typically "Bearer"
        [JsonPropertyName("token_type")]
        public required string TokenType { get; set; }

        // The lifetime in seconds of the access token
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        // The OAuth 2.0 refresh token, if granted (used for getting new access tokens)
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        // The scope of the access token
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        // The ID token for OpenID Connect authentication (if applicable)
        [JsonPropertyName("id_token")]
        public string? IdToken { get; set; }
    }
}
