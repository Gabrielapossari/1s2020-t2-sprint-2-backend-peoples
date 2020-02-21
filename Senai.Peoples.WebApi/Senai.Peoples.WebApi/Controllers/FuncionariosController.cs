using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controller
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos funcionarios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        private IFuncionarios _funcionariosRepository { get; set; }


        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _funcionariosRepository.Listar();
        }
        [HttpPost]
        public IActionResult Post(FuncionariosDomain funcionarios)
        {
            // Faz a chamada para o método .Cadastrar();
            _funcionariosRepository.Cadastrar(funcionarios);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }




    }

}
