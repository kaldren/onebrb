using Onebrb.Api.Entities;
using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onebrb.Spa.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Profile> Authenticate(string username, string password)
        {
            Profile profile = new Profile()
            {
                Username = username,
                Password = password,
                Firstname = string.Empty,
                Lastname = string.Empty,
                Token = string.Empty
            };

            var profileJson = new StringContent(JsonSerializer.Serialize(profile), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/auth", profileJson);

            if (response.IsSuccessStatusCode)
            {
                var profileDeserialized = await JsonSerializer.DeserializeAsync<Profile>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
                return profileDeserialized;
            }

            return null;
        }
    }
}
