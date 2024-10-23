using Laundry_O_Melch_Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Laundry_O_Melch_Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PedidoController(LaundryOMelchDBContext context) : ControllerBase
    {
        private readonly LaundryOMelchDBContext _context = context;

        [HttpGet("GetPedido")]
        public IActionResult Get()
        {
            return Ok(_context.Pedido.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetPedido(int id)
        {
            Pedido? pedido = _context.Pedido.Find(id);

            if (pedido == null)
                return BadRequest();

            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            _context.Pedido.Add(pedido);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }
    }
}
