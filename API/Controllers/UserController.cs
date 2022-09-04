using API.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService,IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
    }
}
