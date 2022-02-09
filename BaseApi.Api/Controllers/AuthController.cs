using AutoMapper;
using BaseApi.Common.DTO.Request;
using BaseApi.Services;
using Common.Response;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApi.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly IUnitOfWork _uow;
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManagerService _authManager;
        private readonly IValidator<LoginDTO> _loginValidator;
        private readonly IValidator<RegisterDTO> _registerValidator;

        public AuthController(
            ILogger<AuthController> logger,
            IMapper mapper,
            IAuthManagerService authManager,
            IValidator<LoginDTO> loginValidator,
            IValidator<RegisterDTO> registerValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegisterDTO registerDTO)
        {
            _logger.LogInformation($"Registration Attemp for {registerDTO.Email}");
            var result = _registerValidator.Validate(registerDTO);
            if (!result.IsValid)
                return BadRequest(result);

            var user = await _authManager.RegisterAsync(registerDTO);
            var userDto = _mapper.Map<UserDTO>(user);
            return Created("", userDto);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO)
        {
            _logger.LogInformation($"Login Attemp for {loginDTO.Email}");
            var result = _loginValidator.Validate(loginDTO);
            if (!result.IsValid)
                return BadRequest(result);

            var (_, token) = await _authManager.AuthenticateAsync(loginDTO);

            return Accepted(token);
        }
    }
}
