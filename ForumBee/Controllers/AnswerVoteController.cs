using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumITUDA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerVoteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork unitOfWork;
        public AnswerVoteController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await unitOfWork.AnswerVotes.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var data = await unitOfWork.AnswerVotes.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateAnswerVoteDto dto)
        {
            try
            {
                var data = await unitOfWork.AnswerVotes.AddAsync(dto);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateAnswerVoteDto dto, Guid id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var check = await unitOfWork.AnswerVotes.GetByIdAsync(id);
                if (check == null)
                {
                    return NotFound();
                }
                var data = await unitOfWork.AnswerVotes.UpdateAsync(dto, id);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var check = await unitOfWork.AnswerVotes.GetByIdAsync(id);
                if (check == null)
                {
                    return NotFound();
                }
                await unitOfWork.AnswerVotes.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
