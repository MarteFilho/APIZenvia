using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/product")]
    public class ProductCatologController : ControllerBase
    {


            private readonly DataContext _context;
            public ProductCatologController(DataContext context)
            {
                _context = context;
            }

            //Retorna uma lista de lojas
            [HttpGet]
            [Route("")]
            public async Task<ActionResult<List<ProductCatalog>>> Get()
            {
                var Products = await _context.ProductCatalog.AsNoTracking().ToListAsync();
                if (Products == null)
                {
                    return NotFound(new { erro = "Nenhum produto encontrado encontrado!" });
                }

                return Ok(Products);
            }


            //Criação de uma loja
            [HttpPost]
            [Route("")]
            public async Task<ActionResult<dynamic>> Post([FromBody] ProductCatalog model)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
                }

                try
                {
                    _context.ProductCatalog.Add(model);
                    await _context.SaveChangesAsync();

                }
                catch
                {
                    return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados!" });
                }
                return new
                {
                    product = model,
                    mesangem = "Produto cadastrado com sucesso!"
                };
            }

        }
    }
