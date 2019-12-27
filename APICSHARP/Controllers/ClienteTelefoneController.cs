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
    public class ClienteTelefoneController : ControllerBase
    {

        public ApplicationDbContext _applicationDbContext;
        public ClienteTelefoneController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteTelefone>>> GetList()
        {
            try
            {
                var list = await _applicationDbContext.ClienteTelefone.ToListAsync();

        

                return list;
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<ClienteTelefone>> GetItem(int id)
        {
            try
            {
                var item = await _applicationDbContext.ClienteTelefone.Include(x => x.Cliente).Where(c => c.Id == id).FirstOrDefaultAsync();
                if (item == null)
                    return NoContent();
                return item;
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var item = await _applicationDbContext.ClienteTelefone.Where(c => c.Id == id).FirstOrDefaultAsync();

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
        public async Task<ActionResult<ClienteTelefone>> PostItem(ClienteTelefone clienteTelefone)
        {
            try
            {
                _applicationDbContext.Entry(clienteTelefone).State = EntityState.Added;
                _applicationDbContext.Add(clienteTelefone);
                await _applicationDbContext.SaveChangesAsync();

                return Ok(clienteTelefone);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteTelefone>> PutItem(int id, ClienteTelefone clienteTelefone)
        {
            try
            {
                if (id != clienteTelefone.Id)
                {
                    return BadRequest();
                }

                _applicationDbContext.Entry(clienteTelefone).State = EntityState.Modified;
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