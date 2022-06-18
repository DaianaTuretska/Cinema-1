using Project.BLL.DTO.Requests;
using Project.BLL.Interfaces.Services;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using Project.DAL.Interfaces.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;

        private IUnitOfWork _unitofWork;
        private IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IUnitOfWork unitofWork, IMovieService cityService)
        {
            _logger = logger;
            _unitofWork = unitofWork;
            _movieService = cityService;
        }


        [HttpPost("PostCity")]
        public async Task<ActionResult> PostCityAsync([FromBody] MovieRequest movie)
        {
            try
            {
                if (movie == null)
                {
                    _logger.LogError("Comment object sent from client is null.");
                    return BadRequest("Comment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Comment object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var created_id = await _movieService.InsertAsync(movie);
                var CreatedCategory = await _movieService.GetByIdAsync(created_id);
                _unitofWork.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PostCommentAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

        [HttpGet("GetAllCity")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllCity()
        {
            try
            {
                var result = await _movieService.GetAsync();
                _unitofWork.Commit();
                _logger.LogInformation($"Returned all movie");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! Something went wrong inside GetCompletedMovieById() action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
