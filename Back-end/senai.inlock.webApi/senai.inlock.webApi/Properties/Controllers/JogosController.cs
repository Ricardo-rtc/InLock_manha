using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Properties.Controllers
{
    [Produces("application/json")]
    
    [Route("api/[controller]")]

    [ApiController]

    //Adicionar o [Authorize} aqui para apenas usuarios com autenticação acessar os métodos 
    public class JogosController : ControllerBase
    {
        private IJogoRepository jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_jogoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
            ///<summary>
            ///Cadastra um novo jogo
            ///</summary>
            ///<param name="novoJogo">Objeto novoJogo com as informações</param>
            ///<returns>Retorna um status code 201 -Created</returns>
            
            [Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Cadastrar(JogosController novoJogo)
            {
                try
                {
                    _jogoRepository.Cadastrar(novoJogo);

                    return StatusCode(201);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
        }
    }
}
