using AutoMapper;
using BaseApi.Common.DTO.Request;
using BaseApi.Common.Response;
using BaseApi.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace WebApi.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthManagerService _authManager;
        private readonly IValidator<LoginDTO> _loginValidator;
        private readonly IValidator<RegisterDTO> _registerValidator;

        public AuthController(
            IMapper mapper,
            IAuthManagerService authManager,
            IValidator<LoginDTO> loginValidator,
            IValidator<RegisterDTO> registerValidator)
        {
            _mapper = mapper;
            _authManager = authManager;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegisterDTO registerDTO)
        {
            Log.Information($"Registration Attemp for {registerDTO.Email}");
            var result = _registerValidator.Validate(registerDTO);
            if (!result.IsValid)
                return BadRequest(result);

            var userDto = await _authManager.RegisterAsync(registerDTO);
            return Created("", userDto);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO)
        {
            Log.Information($"Login Attemp for {loginDTO.Email}");
            var result = _loginValidator.Validate(loginDTO);
            if (!result.IsValid)
                return BadRequest(result);

            var (_, token) = await _authManager.AuthenticateAsync(loginDTO);

            return Ok(new { Token = token });
        }
    }
}
