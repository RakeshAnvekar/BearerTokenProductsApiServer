using Microsoft.AspNetCore.Mvc;
using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.Models.User;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly ILogger<UserController> _logger;
        private readonly ITokenGenerator _tokenGenerator;

        public UserController(IUserLogic userLogic, ILogger<UserController> logger, ITokenGenerator tokenGenerator)
        {
            _logger = logger;
            _userLogic = userLogic;
            _tokenGenerator = tokenGenerator;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLogin userLogin) 
        {
            if (userLogin == null) throw new ArgumentNullException(nameof(userLogin));

            if (string.IsNullOrEmpty(userLogin.UserName)) throw new ArgumentNullException(nameof(userLogin.UserName));
            if (string.IsNullOrEmpty(userLogin.UserPassword)) throw new ArgumentNullException(nameof(userLogin.UserPassword));
           
            try
            {
                var user =await _userLogic.GetAsync(userLogin, HttpContext.RequestAborted);
                if(user == null) return NotFound();
               var tokenValue= await _tokenGenerator.GenerateTokenAsync(user, HttpContext.RequestAborted);
                return Ok(new {Token= tokenValue ,User=user});
            }
            catch (Exception ex) {
                _logger.LogError($"Weeor while getting user details, Exception is : {ex.Message}");
                return BadRequest(ex);
            }
        }
    }
}
