using Microsoft.AspNetCore.Mvc;
using MojePrzepisy.Database.Repositories;
using System;
using System.Threading.Tasks;

namespace MojePrzepisy_API.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class RecepieController : Controller
    {
        //połączenie do startup
        private RecepieRepository _settingsRepository;

        public RecepieController(RecepieRepository settingsRepository)
        {
            //połączenie do bazy danych
            _settingsRepository = settingsRepository;
        }

 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recepie = _settingsRepository.GetAll();
            return Ok(recepie);
        }
    }
}
