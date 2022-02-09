using BaseApi.Common.DTO.Request;
using BaseApi.Core.Entities;
using System.Threading.Tasks;


namespace BaseApi.Services
{
    public interface IAuthManagerService
    {
        Task<(User user, string accessToken)> AuthenticateAsync(LoginDTO loginDto);
        Task<User> RegisterAsync(RegisterDTO loginDto);
    }
}
