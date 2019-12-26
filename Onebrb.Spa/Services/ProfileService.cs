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
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;

        public ProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Profile> GetProfileAsync(string profileId)
        {
            return await JsonSerializer.DeserializeAsync<Profile>
                (await _httpClient.GetStreamAsync($"api/profile/{profileId}"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
