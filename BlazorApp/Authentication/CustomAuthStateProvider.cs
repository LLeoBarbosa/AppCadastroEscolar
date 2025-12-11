using ACE.Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BlazorApp.Authentication
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CustomAuthStateProvider(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        //*************************************************************************************
        //*************************************************************************************

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            using (var scope = _scopeFactory.CreateScope())
            {
                var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                var user = httpContext?.User;

              
                if (user?.Identity?.IsAuthenticated == true)
                {
                 
                    return new AuthenticationState(user);
                }
            }

          
            var principal = new ClaimsPrincipal(new ClaimsIdentity());

            return new AuthenticationState(principal);

        }

        //*************************************************************************************
        //*************************************************************************************

        public async Task<bool> LoginAsync(string email, string password)
        {
            using var scope = _scopeFactory.CreateScope();
            var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<Usuario>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();

            var usuario = await userManager.FindByEmailAsync(email);
            if (usuario == null) return false;

            var result = await signInManager.PasswordSignInAsync(usuario.UserName, password, false, false);

            if (result.Succeeded)
            {
             
                NotifyAuthenticationStateChanged();
                return true;
            }

            return false;
        }                       

        //*************************************************************************************
        //*************************************************************************************

        public async Task LogoutAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<Usuario>>();

             
                await signInManager.SignOutAsync();
            }

        
            NotifyAuthenticationStateChanged();
        }

        //*************************************************************************************
        //*************************************************************************************

        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

    }
}
