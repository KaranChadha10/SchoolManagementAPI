using API.DTOs;
using API.DTOs.Department;
using API.Filters;
using API.IServices;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[Action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetDepartmentDTO>>> GetAllDepartmentDetails([FromQuery] DepartmentFilter filter)
        {
            return Ok(await _departmentService.GetAllDepartmentDetails(filter));
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetDepartmentDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetDepartmentDTO>> GetDepartmentById(int id)
        {

            var department = await _departmentService.GetDepartmentDetailById(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<GetDepartmentDTO>> Create([FromBody] CreateDepartmentDTO dto)
        {
            //dto.Created_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            return Ok(await _departmentService.CreateDepartmentDetail(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetDepartmentDTO>> Update(int id, [FromBody] UpdateDepartmentDTO dto)
        {
            //dto.Modified_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            var department = await _departmentService.UpdateDepartmentDetail(id, dto);

            if (department == null) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _departmentService.DeleteDepartment(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
