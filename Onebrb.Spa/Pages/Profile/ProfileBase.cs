using Microsoft.AspNetCore.Components;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces.Services;
using Onebrb.Spa.Services;
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
        public string ProfileId { get; set; }

        [Inject]
        public IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProfileId != null && int.TryParse(ProfileId, out int idParameter))
            {
                Profile = (await ProfileService.GetProfileAsync(idParameter));
            }
            else
            {
                int loggedInUserId = ProfileService.GetLoggedInUserId();

                Profile = (await ProfileService.GetProfileAsync(loggedInUserId));
            }
        }
    }
}
