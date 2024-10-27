using Microsoft.AspNetCore.Http;
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

        public UserController(IUserLogic userLogic, ILogger<UserController> logger)
        {
            _logger = logger;
            _userLogic = userLogic;
        }
        [HttpPost]
        public async Task<IActionResult> Get(UserLogin userLogin) 
        {
            if (userLogin == null) throw new ArgumentNullException(nameof(userLogin));

            if (string.IsNullOrEmpty(userLogin.UserName)) throw new ArgumentNullException(nameof(userLogin.UserName));
            if (string.IsNullOrEmpty(userLogin.UserPassword)) throw new ArgumentNullException(nameof(userLogin.UserPassword));
           
            try
            {
                var user =await _userLogic.GetAsync(userLogin, HttpContext.RequestAborted);
                if(user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception ex) {
                _logger.LogError($"Weeor while getting user details, Exception is : {ex.Message}");
                return BadRequest(ex);
            }
        }
    }
}
