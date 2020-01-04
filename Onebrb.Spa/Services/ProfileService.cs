using Microsoft.AspNetCore.Http;
using Onebrb.Core.Entities;
using Onebrb.Core.Enumerations;
using Onebrb.Core.Interfaces.Services;
using Onebrb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onebrb.Spa.Services
{
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ProfileModel> GetProfileAsync(int profileId)
        {
            try
            {
                ProfileModel profile = await JsonSerializer.DeserializeAsync<ProfileModel>
                    (await _httpClient.GetStreamAsync($"/profiles/{profileId}"), new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return profile;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is JsonException)
            {
                // May log it later
                return null;
            }
        }

        public async Task<ProfileModel> GetProfileAsync(string nickname)
        {
            try
            {
                ProfileModel profile = await JsonSerializer.DeserializeAsync<ProfileModel>
                    (await _httpClient.GetStreamAsync($"/profiles/{nickname}"), new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return profile;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is JsonException)
            {
                // May log it later
                return null;
            }
        }

        public async Task<ProfileModel> GetLoggedInUserProfile()
        {
            int loggedInUserId = GetLoggedInUserId();

            return await GetProfileAsync(loggedInUserId);
        }

        public int GetLoggedInUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
