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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o filme buscado no banco de dados
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            // Verifica se nenhum funcionario foi encontrado
            if (funcionarioBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum funcionario encontrado");
            }

            // Caso seja encontrado, retorna o funcionario buscado
            return Ok(funcionarioBuscado);
        }
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionariosDomain funcionarioAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (funcionarioBuscado == null)
            {
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado",
                            erro = true
                        }
                    );
            }
            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl();
                _funcionariosRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna BadRequest e o erro
                return BadRequest(erro);
            }
        }
            [HttpPut]
        public IActionResult PutIdCorpo(FuncionariosDomain funcionarioAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FuncionariosDomain FuncionarioBuscado = _funcionariosRepository.BuscarPorId(funcionarioAtualizado.ID_Funcionarios);

            // Verifica se algum gênero foi encontrado
            if (FuncionarioBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo();
                    _funcionariosRepository.AtualizarIdCorpo(funcionarioAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionario não encontrado",
                        erro = true
                    }
                );
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            _funcionariosRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Funcionario deletado");
        }
    }
 }






    


