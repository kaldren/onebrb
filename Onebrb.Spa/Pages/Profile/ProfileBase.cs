using Microsoft.AspNetCore.Components;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces.Services;
using Onebrb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Pages.Profile
{
    public class ProfileBase : ComponentBase
    {
        public Core.Models.ProfileModel Profile { get; set; }

        [Parameter]
        public int? ProfileId { get; set; }

        [Parameter]
        public string ProfileNickname { get; set; }

        [Inject]
        public IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProfileId != null)
            {
                Profile = (await ProfileService.GetProfileAsync(ProfileId.Value)) ?? (await ProfileService.GetLoggedInUserProfile());
            }
            else if (ProfileNickname != null)
            {
                Profile = (await ProfileService.GetProfileAsync(ProfileNickname)) ?? (await ProfileService.GetLoggedInUserProfile());
            }
            else
            {
                Profile = (await ProfileService.GetLoggedInUserProfile());
            }
        }
    }
}
