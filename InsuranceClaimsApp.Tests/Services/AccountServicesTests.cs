
using InsuranceClaimsApp.Exceptions;
using InsuranceClaimsApp.Interfaces.Services;
using InsuranceClaimsApp.Services;
using InsuranceClaimsApp.Tests.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace InsuranceClaimsApp.Tests.Services
{
    public class AccountServicesTests
    {

        [Fact]
        public async Task Authenticate_ActiveUser_GenerateClaims()
        {
            // Arrange
            IAccountService accountService = new AccountService(DatabaseHelper.GetInterviewContext());

            var expectedClaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "gemmela")
                }, CookieAuthenticationDefaults.AuthenticationScheme));
            // Act
            var actualClaimsPrincipal = await accountService.AuthenticateUser(new Models.Account.LoginInputModel()
            {
                Username = "gemmela",
                Password = "Archie"
            });

            // Assert
            Assert.Equal(expectedClaimsPrincipal.Identity.Name, actualClaimsPrincipal.Identity.Name);
        }

        [Fact]
        public async Task Authenticate_InactiveUser_ThrowFailedAuthenticationException()
        {
            // Arrange
            IAccountService accountService = new AccountService(DatabaseHelper.GetInterviewContext());

            // Act Assert
            FailedAuthenticationException failedAuthenticationException = await Assert.ThrowsAsync<FailedAuthenticationException>(async () => await accountService.AuthenticateUser(new Models.Account.LoginInputModel()
            {
                Username = "bestg",
                Password = "Georgie"
            }));

            Assert.Equal("Invalid credentials", failedAuthenticationException.Message);
        }

        [Fact]
        public async Task Authenticate_ActiveUserIncorrectPassword_ThrowFailedAuthenticationException()
        {
            // Arrange
            IAccountService accountService = new AccountService(DatabaseHelper.GetInterviewContext());
            // Act Assert
            FailedAuthenticationException failedAuthenticationException = await Assert.ThrowsAsync<FailedAuthenticationException>(async () => await accountService.AuthenticateUser(new Models.Account.LoginInputModel()
            {
                Username = "gemmela",
                Password = "Arche"
            }));

            Assert.Equal("Invalid username or password", failedAuthenticationException.Message);
        }

        [Fact]
        public async Task Authenticate_NonExistingUser_ThrowFailedAuthenticationException()
        {
            // Arrange
            IAccountService accountService = new AccountService(DatabaseHelper.GetInterviewContext());
            // Act Assert
            FailedAuthenticationException failedAuthenticationException = await Assert.ThrowsAsync<FailedAuthenticationException>(async () => await accountService.AuthenticateUser(new Models.Account.LoginInputModel()
            {
                Username = "gema",
                Password = "Arche"
            }));

            Assert.Equal("Invalid username or password", failedAuthenticationException.Message);
        }
    }
}