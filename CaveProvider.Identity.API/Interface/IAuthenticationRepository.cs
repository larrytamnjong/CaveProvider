using CaveProvider.Core.Helpers.Responses;
using CaveProvider.Identity.API.Dto;

namespace CaveProvider.Identity.API.Interface
{
    public interface IAuthenticationRepository
    {
        Task<ServiceResponseBase> SignUp(ApplicationUserDto applicationUserDto);
        Task<ServiceResponseBase> SignIn(LoginDto loginDto);
        Task<ApplicationUserDto> GetSignedInUser(string userId);
    }
}
 