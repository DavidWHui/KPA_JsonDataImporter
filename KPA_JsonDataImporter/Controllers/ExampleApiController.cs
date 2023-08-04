using KPA_JsonDataImporter.Models;
using KPA_JsonDataImporter.Services;
using Microsoft.AspNetCore.Mvc;

namespace KPA_JsonDataImporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleApiController : ControllerBase
    {
        private readonly ILogger<ExampleApiController> _logger;
        private readonly ExampleService _exampleService;

        public ExampleApiController(ILogger<ExampleApiController> logger)
        {
            _logger = logger;
            _exampleService = new ExampleService();
        }

        /* 
         * Returns a list of the available Example Models
         */
        [HttpGet]
        [Route("getexamplelist")]
        public async Task<ActionResult<IEnumerable<ExampleModel>>> GetExampleList()
        {
            try
            {
                return Ok(await _exampleService.GetExampleList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        /* 
         * Returns a singular Example
         */
        [HttpGet]
        [Route("getexample")]
        public async Task<ActionResult<ExampleModel>> GetExample(int id)
        {
            try
            {
                return Ok(await _exampleService.GetExamplel(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        /* 
         * Takes a uploaded json file and calls service to parse and store data.
         */
        [HttpPost]
        [Route("importjson")]
        public async Task<IActionResult> ImportJson(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("File was null");
            }

            try
            {
                await _exampleService.ImportJsonData(file);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}