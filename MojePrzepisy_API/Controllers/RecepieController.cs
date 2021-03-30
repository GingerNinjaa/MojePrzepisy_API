using Microsoft.AspNetCore.Mvc;
using MojePrzepisy.Database.Entities;
using MojePrzepisy.Database.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace MojePrzepisy_API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class RecepieController : Controller
    {
        //połączenie do startup
        private RecepieRepository _settingsRepository;
        //private readonly IRecepieRepository _recepieRepository;

        public
            RecepieController(
                RecepieRepository settingsRepository) //, IRecepieRepository recepieRepository,  RecepieRepository _settingsRepository
        {
            //połączenie do bazy danych
            _settingsRepository = settingsRepository;
            //_recepieRepository = recepieRepository;
        }
        [Authorize]
        [HttpGet("{id}")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Get(int id)
        {
            var recepie = await _settingsRepository.GetRecepieById(id);
            //var recepie = _recepieRepository.GetAll();
            return Ok(recepie);
        }

        [Authorize]
        [HttpGet("[action]")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult AllRecepiesPartial(int? pageNumber, int? pageSize)
        {
            var recepiePartial = _settingsRepository.GetRecepiePaginated(pageNumber, pageSize);

            return Ok(recepiePartial);
        }

        [Authorize]
        [HttpGet("[action]")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult FindRecepies(string recipeTitle)
        {
            var recepie = _settingsRepository.FindRecepie(recipeTitle);

            return Ok(recepie);
        }

        [Authorize]
        [HttpPost("[action]")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult AddRecepie([FromBody] Recepie recepie)
        {
            bool resoult = _settingsRepository.AddRecepie(recepie);

            if (resoult == true)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
            
        }


        [Authorize]
        [HttpPost("[action]")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult AddRecepieImg([FromForm] Recepie recepie)
        {
            bool resoult = _settingsRepository.AddRecepieImg(recepie);

            if (resoult == true)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
        }

        [Authorize]
        [HttpPut("[action]")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult UpdateRecepie([FromBody] Recepie recepie ,int id)
        {
            var resoult = _settingsRepository.EditRecepie(id, recepie);

            if (resoult == true)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
        }

        [Authorize]
        [HttpPut("[action]")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult UpdateRecepieImg([FromBody] Recepie recepie, int id)
        {
            var resoult = _settingsRepository.EditRecepieIMG(id, recepie);

            if (resoult == true)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
        }

        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteRecepie(int id)
        {
            var resoult = _settingsRepository.DeleteById(id);

            if (resoult == true)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
        }
    }
}
