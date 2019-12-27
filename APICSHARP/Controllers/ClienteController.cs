using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICSHARP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICSHARP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public ApplicationDbContext _applicationDbContext;
        public ClienteController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<ClienteViewModel>>> GetList()
        {
            try
            {
                var list = await _applicationDbContext.Cliente.ToListAsync();

                var listFull = list.Select(x => new ClienteViewModel
                {
                    Id = x.Id,
                    Cpf = x.Cpf,
                    DataNascimento = x.DataNascimento,
                    Idade = x.Idade,
                    LimiteCredito = x.LimiteCredito,
                    Nome = x.Nome,
                    clienteTelefone = _applicationDbContext.ClienteTelefone.Where(y => y.ClienteId == x.Id).Select(z => z.Telefone).ToList()
                }).ToList();

                return listFull;
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetItem(int id)
        {
            try
            {
                var item = await _applicationDbContext.Cliente.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (item == null)
                    return NoContent();
                return item;
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var item = await _applicationDbContext.Cliente.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (item == null)
                    return NoContent();

                _applicationDbContext.Remove(item);
                await _applicationDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostItem(Cliente cliente)
        {
            try
            {
                _applicationDbContext.Entry(cliente).State = EntityState.Added;
                _applicationDbContext.Add(cliente);
                await _applicationDbContext.SaveChangesAsync();

                return Ok(cliente);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> PutItem(int id, Cliente cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    return BadRequest();
                }
                _applicationDbContext.Entry(cliente).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}