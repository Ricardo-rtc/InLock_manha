using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Properties.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Properties.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet("Jogos")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
