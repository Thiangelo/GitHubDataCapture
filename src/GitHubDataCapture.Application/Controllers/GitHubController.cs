using AutoMapper;
using GitHubDataCapture.Application.DTO;
using GitHubDataCapture.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GitHubDataCapture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private IGitHubService _gitHubService;
        private IMapper _mapper;
        public GitHubController(IGitHubService gitHubService, IMapper mapper)
        {
            _gitHubService = gitHubService;
            _mapper = mapper;
        }

        [HttpGet("getalldetailedrepositories")]
        public IActionResult GetallDetailedRepositories()
        {
            try
            {
                var response = _gitHubService.GetAllRepositories();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("getallbasicrepositories")]
        public IActionResult GetAllBasicRepositories()
        {
            try
            {
                var response = _gitHubService.GetAllRepositories();
                var respositoryBasicDataDTO = _mapper.Map<List<RepositoryBasicDataDTO>>(response);
                return Ok(respositoryBasicDataDTO);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("searchandsaverepositories")]
        public async Task<IActionResult> SearchAndSaveRepositories()
        {
            try
            {
                var response = await _gitHubService.SearchAndSaveRepositories();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
