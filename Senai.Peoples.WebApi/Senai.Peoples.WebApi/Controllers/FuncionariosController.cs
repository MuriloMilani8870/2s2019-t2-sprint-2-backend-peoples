using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class FuncionariosController : Controller
    {

        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Listar()
        {

            // return estilos;
            return funcionarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain Funcionario = funcionarioRepository.BuscarPorId(id);
            if (Funcionario == null)
            {
                return NotFound();
            }
            return Ok(Funcionario);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }
    }
}