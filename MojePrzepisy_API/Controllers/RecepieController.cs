using Microsoft.AspNetCore.Mvc;
using MojePrzepisy.Database.Repositories;
using System;
using System.Threading.Tasks;
using MojePrzepisy.Database.Repositories.Interfaces;

namespace MojePrzepisy_API.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class RecepieController : Controller
    {
        //połączenie do startup
        private RecepieRepository _settingsRepository;
        //private readonly IRecepieRepository _recepieRepository;

        public RecepieController(RecepieRepository settingsRepository) //, IRecepieRepository recepieRepository,  RecepieRepository _settingsRepository
        {
            //połączenie do bazy danych
            _settingsRepository = settingsRepository;
            //_recepieRepository = recepieRepository;
        }

 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var recepie = _settingsRepository.GetRecepieById(id);
            //var recepie = _recepieRepository.GetAll();
            return Ok(recepie);
        }
    }
}
