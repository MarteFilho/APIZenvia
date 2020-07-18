using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        public CustomerController(DataContext context)
        {
            _context = context;
        }

        //Retorna uma lista de clientes
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            var Customers = await _context.Customer.AsNoTracking().ToListAsync();
            if (Customers == null)
            {
                return NotFound(new { erro = "Nenhum cliente encontrado!" });
            }

            return Ok(Customers);
        }

        //Criação de uma loja
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> Post([FromBody] Customer model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
            }

            try
            {
                _context.Customer.Add(model);
                await _context.SaveChangesAsync();

            }
            catch
            {

                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados!" });
            }
            return new
            {
                customer = model,
                mesangem = "Cliente cadastrado com sucesso!"
            };
        }

    }
}
