using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumITUDA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork unitOfWork;
        public BlogCategoryController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await unitOfWork.BlogCategories.GetAllAsync();
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
                var data = await unitOfWork.BlogCategories.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateBlogCategoryDto dto)
        {
            try
            {
                var data = await unitOfWork.BlogCategories.AddAsync(dto);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateBlogCategoryDto dto, Guid id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var check = await unitOfWork.BlogCategories.GetByIdAsync(id);
                if (check == null)
                {
                    return NotFound();
                }
                var data = await unitOfWork.BlogCategories.UpdateAsync(dto, id);
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
                var check = await unitOfWork.BlogCategories.GetByIdAsync(id);
                if (check == null)
                {
                    return NotFound();
                }
                await unitOfWork.BlogCategories.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
