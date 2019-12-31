﻿using Microsoft.AspNetCore.Http;
using Onebrb.Core.Entities;
using Onebrb.Core.Enumerations;
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

        public async Task<Profile> GetProfileAsync(int profileId)
        {
            Profile profile = await JsonSerializer.DeserializeAsync<Profile>
                (await _httpClient.GetStreamAsync($"/profiles/{profileId}"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            // Checks if the profile belongs to the logged in user or not
            // and marks the profile accordingly.
            if (profile != null && profile.ProfileId == profileId)
            {
                profile.ProfileType = ProfileTypeEnum.OwnProfile;
            }
            else
            {
                profile.ProfileType = ProfileTypeEnum.NotOwnProfile;
            }

            return profile;
        }

        public Task<Profile> GetProfileAsync()
        {
            throw new NotImplementedException();
        }

        public int GetLoggedInUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
