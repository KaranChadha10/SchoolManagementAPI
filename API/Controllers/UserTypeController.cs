using API.DTOs;
using API.DTOs.UserType;
using API.Filters;
using API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetUserTypeDTO>>> GetAllUserTypeDetails([FromQuery] UserTypeFilter filter)
        {
            return Ok(await _userTypeService.GetAllUserTypeDetails(filter));
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetUserTypeDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserTypeDTO>> GetUserTypeById(int id)
        {

            var UserType = await _userTypeService.GetUserTypeDetailById(id);
            if (UserType == null) return NotFound();
            return Ok(UserType);
        }

        [HttpPost]
        public async Task<ActionResult<GetUserTypeDTO>> Create([FromBody] CreateUserTypeDTO dto)
        {
            //dto.Created_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            return Ok(await _userTypeService.CreateUserTypeDetail(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetUserTypeDTO>> Update(int id, [FromBody] UpdateUserTypeDTO dto)
        {
            //dto.Modified_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            var userTypeDTO = await _userTypeService.UpdateUserTypeDetail(id, dto);

            if (userTypeDTO == null) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _userTypeService.DeleteUserType(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
