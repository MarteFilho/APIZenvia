using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/category")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }



        //Retorna uma lista de categorias
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var Categories = await _context.Store.AsNoTracking().ToListAsync();
            if (Categories == null)
            {
                return NotFound(new { erro = "Nenhuma categoria encontrada encontrado!" });
            }

            return Ok(Categories);
        }

        //Criação de uma categoria
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> Post([FromBody]Category model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
            }

            try
            {
                _context.Category.Add(model);
                await _context.SaveChangesAsync();

            }
            catch
            {

                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados!" });
            }
            return new
            {
                catgoria = model,
                mesangem = "Categoria cadastrada com sucesso!"
            };
        }


    }
}
