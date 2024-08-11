//using BL.Interfaces; // Use the namespace where ILogIn is defined
//using BL.Services;
//using DAL.DTO;
//using DAL.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using MODELS.Models;
//using System.Threading.Tasks;

//namespace FinalProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LogInController : ControllerBase
//    {
//        private readonly ILogger<LogInController> _logger;
//        private readonly ILogIn _logInService;

//        public LogInController(ILogger<LogInController> logger, ILogIn logInService)
//        {
//            _logger = logger;
//            _logInService = logInService;
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] LoginModel loginRequest)
//        {
//            var userFind = await _logInService.ValidateUserAsync(loginRequest.id, loginRequest.password);

//            if (userFind != null)
//            {
//                var tokenString = _logInService.GenerateJwtToken(userFind);

//                var cookieOptions = new CookieOptions
//                {
//                    HttpOnly = true, // לקוקי לא תהיה גישה מצד JavaScript
//                    Secure = true, // הקוקי יהיה זמין רק בפרוטוקול HTTPS
//                    SameSite = SameSiteMode.Strict, // מניעת שליחה עם בקשות צד שלישי
//                    Expires = DateTime.UtcNow.AddHours(1) // תוקף הקוקי
//                };

//                Response.Cookies.Append("AuthToken", tokenString, cookieOptions);
//                return Ok();
//            }

//            return Unauthorized("Invalid credentials.");
//        }
//    }

//    public class LoginModel
//    {
//        public string id { get; set; }
//        public string password { get; set; }
//    }

//    public class RegisterModel
//    {
//        public string id { get; set; }
//        public string password { get; set; }
//    }
//}
using BL.Interfaces;
using BL.Services;
using DAL.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MODELS.Models;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpLoginControllers : ControllerBase
    {
        private readonly ILogger<SignUpLoginControllers> _logger;
        private readonly ILogIn _logInService;
        private readonly IUsers _userService;

        public SignUpLoginControllers(ILogger<SignUpLoginControllers> logger, ILogIn logInService, IUsers userService)
        {
            _logger = logger;
            _logInService = logInService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel registerRequest)
        {
            if (registerRequest == null || string.IsNullOrEmpty(registerRequest.userId) || string.IsNullOrEmpty(registerRequest.password))
            {
                return BadRequest("Invalid user data.");
            }

            // Convert RegisterModel to UsersDTO
            var userDto = new UsersDTO
            {
                userId = registerRequest.userId,
                password = registerRequest.password,
                firstName = registerRequest.firstName,
                lastName = registerRequest.lastName,
                isAdmin = registerRequest.isAdmin,


                // Set other properties if needed
            };

            // Create the user
            bool createUserResult = await _userService.CreateUser(userDto);

            if (!createUserResult)
            {
                return BadRequest("Failed to create user.");
            }

            // Automatically log in the user
            return await Login(new LoginModel
            {
                userId = registerRequest.userId,
                password = registerRequest.password,
                

            });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginRequest)
        {
            var userFind = await _logInService.ValidateUserAsync(loginRequest.userId, loginRequest.password);

            if (userFind != null)
            {
                var tokenString = _logInService.GenerateJwtToken(userFind);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddHours(1)
                };

                Response.Cookies.Append("AuthToken", tokenString, cookieOptions);
                return Ok();
            }

            return Unauthorized("Invalid credentials.");
        }
    }

    public class LoginModel
    {
        public string userId { get; set; }
        public string password { get; set; }
    }

    public class RegisterModel
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int isAdmin { get; set; }

    }
}