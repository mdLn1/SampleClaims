using InsuranceClaimsApp.Models.Account;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsuranceClaimsApp.Interfaces.Services
{
    public interface IAccountService
    {
        public Task<ClaimsPrincipal> AuthenticateUser(LoginInputModel loginModel);
    }
}