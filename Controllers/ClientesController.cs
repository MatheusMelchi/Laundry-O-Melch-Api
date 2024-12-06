using Laundry_O_Melch_Api.DTOs;
using Laundry_O_Melch_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Laundry_O_Melch_Api.Controllers
{
    [Route("Api/[controller]")]
    public class ClientesController(LaundryOMelchDBContext context) : ControllerBase
    {
        private readonly LaundryOMelchDBContext _context = context;

        [HttpGet("GetClientes")]
        public IActionResult Get()
        {
            return Ok(_context.Cliente.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            Cliente? cliente = _context.Cliente.Find(id);

            if(cliente == null)
                return BadRequest("Cliente não encontrado");

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if(cliente == null) 
                return BadRequest();

            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPost("Lista")]
        public IActionResult ClientesLista([FromBody] ClienteFiltro filtros)
        {
            var lista = from cliente in _context.Cliente
                        where cliente.Nome.Contains(filtros.Nome)
                        || cliente.Email.Contains(filtros.Email)
                        || cliente.Cpf.Contains(filtros.Cpf)
                        || cliente.Celular.Contains(filtros.Celular)
                        || cliente.Cnpj.Contains(filtros.Cnpj)
                        || (filtros.Todos ?? false) ? true : false
                        select cliente;

            return Ok(lista);
        }
    }
}
