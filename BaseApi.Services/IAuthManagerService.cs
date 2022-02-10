using BaseApi.Common.DTO.Request;
using BaseApi.Common.Response;
using System.Threading.Tasks;


namespace BaseApi.Services
{
    public interface IAuthManagerService
    {
        Task<(UserDTO userDto, string accessToken)> AuthenticateAsync(LoginDTO loginDto);
        Task<UserDTO> RegisterAsync(RegisterDTO loginDto);
    }
}
