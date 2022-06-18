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
    public class SeanceController : Controller
    {
        private readonly ILogger<SeanceController> _logger;

        private IUnitOfWork _unitofWork;
        private ISeanceService _seanceService;

        public SeanceController(ILogger<SeanceController> logger, IUnitOfWork unitofWork, ISeanceService seanceService)
        {
            _logger = logger;
            _unitofWork = unitofWork;
            _seanceService = seanceService;
        }


        [HttpPost("PostSeance")]
        public async Task<ActionResult> PostSeanceAsync([FromBody] SeanceRequest seance)
        {
            try
            {
                if (seance == null)
                {
                    _logger.LogError("Comment object sent from client is null.");
                    return BadRequest("Comment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Comment object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var created_id = await _seanceService.InsertAsync(seance);
                var CreatedCategory = await _seanceService.GetByIdAsync(created_id);
                _unitofWork.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PostCommentAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

        [HttpGet("GetAllSeance")]
        public async Task<ActionResult<IEnumerable<Seance>>> GetAllSeances()
        {
            try
            {
                var result = await _seanceService.GetAsync();
                _unitofWork.Commit();
                _logger.LogInformation($"Returned all city");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! Something went wrong inside GetCompletedMovieById() action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("GetSeanceByMovieIdSP")]
        public async Task<ActionResult<IEnumerable<Seance>>> GetSeanceByMovieId(int id)
        {
            try
            {
                var result = await _seanceService.GetByIdAsync(id);
                _unitofWork.Commit();
                _logger.LogInformation($"Returned all city");
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
