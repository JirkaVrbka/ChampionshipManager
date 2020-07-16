using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace ChampionshipManager.Web.Utils
{
    public static class AuthenticationStateProviderExtension
    {
        public static async Task<string> GetUserIdentity(this AuthenticationStateProvider provider)
        {
            var user = (await provider.GetAuthenticationStateAsync()).User;
            return user.Identity.Name;
        }
    }
}