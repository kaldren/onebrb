using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Onebrb.Spa.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Components
{
    /// <summary>
    /// Redirects to login page if the visitor isn't authorized
    /// </summary>
    public class RedirectToLogin : ComponentBase
    {
        private readonly UriConfiguration _uriConfig;

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        public RedirectToLogin(IOptions<UriConfiguration> uriConfig)
        {
            _uriConfig = uriConfig.Value;
        }

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo(_uriConfig.LoginPage);
        }
    }
}
