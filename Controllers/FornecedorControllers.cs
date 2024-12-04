using CadastroPedidosFornecedores.Models;
using CadastroPedidosFornecedores.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPedidosFornecedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var fornecedores = _fornecedorRepository.GetAll();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");
            
            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest("Fornecedor inválido.");

            _fornecedorRepository.Add(fornecedor);
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null || fornecedor.Id != id)
                return BadRequest("Dados inválidos para atualização.");

            var existingFornecedor = _fornecedorRepository.GetById(id);
            if (existingFornecedor == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            _fornecedorRepository.Update(fornecedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            _fornecedorRepository.Delete(id);
            return NoContent();
        }
    }
}
