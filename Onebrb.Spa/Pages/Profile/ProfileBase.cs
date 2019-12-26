using Microsoft.AspNetCore.Components;
using Onebrb.Core.Entities;
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
        public Core.Entities.Profile Profile { get; set; }

        [Parameter]
        public string ProfileId { get; set; }

        [Inject]
        public IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Profile = (await ProfileService.GetProfileAsync(ProfileId));
        }
    }
}
