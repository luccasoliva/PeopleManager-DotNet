using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Contracts.Pessoa;
using PeopleManager.Data;
using PeopleManager.Models;
 
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaDbContext _context;
        private readonly IMapper _mapper;
        
        public PessoaController(PessoaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllPessoas()
        {
            var pessoas = await _mapper
                .ProjectTo<PessoaResponse>(_context.Pessoas)
                .ToListAsync();
            
            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoa([FromBody] PessoaRequest request)
        {
             
            var pessoa = _mapper.Map(request, new Pessoa());

            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetPessoa), new { pessoa.Id }, pessoa);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoa([FromRoute] Guid id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            
            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PessoaResponse>(pessoa));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePessoa(Guid id, [FromBody] PessoaRequest request)
        {


            var pessoaDb = await _context.Pessoas.FindAsync(id);
            
            if (pessoaDb == null)
            {
                return NotFound("Não encontrada pessoa de Id: " + id);
            }
            
            _mapper.Map(request, pessoaDb);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa([FromRoute] Guid id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            
            if (pessoa == null)
            {
                return NotFound("Não encontrada pessoa de Id: " + id);
            }
            
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }


    }
}
