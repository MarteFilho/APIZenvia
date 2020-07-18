using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/store")]
    public class StoreController : ControllerBase
    {

        
        private readonly DataContext _context;
        public StoreController(DataContext context)
        {
            _context = context;
        }

        //Retorna uma lista de lojas
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Store>>> Get()
        {
            var Stores = await _context.Store.AsNoTracking().ToListAsync();
            if (Stores == null)
            {
                return NotFound(new { erro = "Nenhuma loja encontrada encontrado!" });
            }

            return Ok(Stores);
        }


        //Criação de uma loja
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> Post([FromBody] Store model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
            }

            try
            {
                _context.Store.Add(model);
                await _context.SaveChangesAsync();

            }
            catch
            {

                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados!" });
            }
            return new
            {
                store = model,
                mesangem = "Loja cadastrada com sucesso!"
            };
        }


    }
}
