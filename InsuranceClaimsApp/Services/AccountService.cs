using InsuranceClaimsApp.ContextData;
using InsuranceClaimsApp.Exceptions;
using InsuranceClaimsApp.Interfaces.Services;
using InsuranceClaimsApp.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsuranceClaimsApp.Services
{
    public class AccountService : IAccountService
    {
        #region Private

        private readonly InterviewContext _interviewContext;

        #endregion Private

        #region Public

        public AccountService(InterviewContext interviewContext)
        {
            _interviewContext = interviewContext;
        }

        public async Task<ClaimsPrincipal> AuthenticateUser(LoginInputModel loginModel)
        {
            var foundUser = await _interviewContext.Users.FirstOrDefaultAsync(x => x.UserName == loginModel.Username);

            if (foundUser == null || foundUser.Password != loginModel.Password)
            {
                throw new FailedAuthenticationException("Invalid username or password");
            }

            if (!foundUser.Active.HasValue || !foundUser.Active.Value)
            {
                // we won't let anyone know that this user exists if it is inactive
                throw new FailedAuthenticationException("Invalid credentials");
            }

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, foundUser.UserName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(identity);
        }

        #endregion Public
    }
}