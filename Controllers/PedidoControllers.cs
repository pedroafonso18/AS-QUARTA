using CadastroPedidosFornecedores.Models;
using CadastroPedidosFornecedores.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPedidosFornecedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_pedidoRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pedido = _pedidoRepository.GetById(id);
            return pedido == null ? NotFound() : Ok(pedido);
        }

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            _pedidoRepository.Add(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest();
            _pedidoRepository.Update(pedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pedidoRepository.Delete(id);
            return NoContent();
        }
    }
}
