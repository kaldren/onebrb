﻿using Microsoft.AspNetCore.Http;
using Onebrb.Core.Entities;
using Onebrb.Core.Enumerations;
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
            ProfileModel profile = await JsonSerializer.DeserializeAsync<ProfileModel>
                (await _httpClient.GetStreamAsync($"/profiles/{profileId}"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

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
