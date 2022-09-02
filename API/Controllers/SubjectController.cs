using API.DTOs;
using API.DTOs.Subject;
using API.Filters;
using API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[Action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetSubjectDTO>>> GetAllSubjectDetails([FromQuery] SubjectFilter filter)
        {
            return Ok(await _subjectService.GetAllSubjectDetails(filter));
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetSubjectDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetSubjectDTO>> GetSubjectById(int id)
        {

            var subject = await _subjectService.GetSubjectDetailById(id);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<GetSubjectDTO>> Create([FromBody] CreateSubjectDTO dto)
        {
            //dto.Created_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            return Ok(await _subjectService.CreateSubjectDetail(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetSubjectDTO>> Update(int id, [FromBody] UpdateSubjectDTO dto)
        {
            //dto.Modified_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            var subject = await _subjectService.UpdateSubjectDetail(id, dto);

            if (subject == null) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _subjectService.DeleteSubject(id);
            if (deleted) return NoContent();
            return NotFound();
        }

    }
}
