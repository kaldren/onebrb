using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Onebrb.Spa.Configurations;

namespace Onebrb.Spa.Components
{
    public class WelcomeHomepageBase : ComponentBase
    {
        protected string WelcomeMessage { get; set; }
        protected string LoginPageUrl { get; set; }
        protected string RegisterPageUrl { get; set; }
        protected string AboutPageUrl { get; set; }

        [Inject]
        IOptionsSnapshot<UriConfiguration> UriConfig { get; set; }
        [Inject]
        IOptionsSnapshot<UIConfiguration> UIConfig { get; set; }

        protected override void OnInitialized()
        {
            LoginPageUrl = UriConfig.Value.LoginPage;
            RegisterPageUrl = UriConfig.Value.RegisterPage;
            AboutPageUrl = UriConfig.Value.AboutPage;
            WelcomeMessage = UIConfig.Value.HomepageWelcomeText;
        }
    }
}
