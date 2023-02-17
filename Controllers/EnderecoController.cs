using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Contracts.Endereco;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class EnderecoController : ControllerBase
        {
            private readonly PessoaDbContext _context;
            private readonly IMapper _mapper;

            public EnderecoController(PessoaDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            [HttpGet]
            public async Task<IActionResult> GetAllEnderecos()
            {
                var enderecos = await _mapper
                    .ProjectTo<EnderecoResponse>(_context.Enderecos)
                    .ToListAsync();

                return Ok(enderecos);
            }

            [HttpGet("principal/{pessoaId}")]
            public async Task<IActionResult> GetEnderecoPrincipal([FromRoute] Guid pessoaId)
            {
                var endereco = await _mapper
                    .ProjectTo<EnderecoResponse>(_context.Enderecos.Where(e => e.PessoaId == pessoaId && e.IsPrincipal))
                    .FirstOrDefaultAsync();

                return Ok(endereco);    
            }

            [HttpGet("{pessoaId}")]
            public async Task<IActionResult> GetEnderecoByPessoa([FromRoute] Guid pessoaId)
            {
                 var enderecos = await _mapper
                    .ProjectTo<EnderecoResponse>(_context.Enderecos.Where(e => e.PessoaId == pessoaId))
                    .ToListAsync();

                return Ok(enderecos);
            }

            [HttpPost("{pessoaId}")]
            public async Task<IActionResult> CreateEndereco([FromRoute] Guid pessoaId,
                [FromBody] EnderecoRequest request)
            {
                var endereco = _mapper.Map(request, new Endereco());
                
                endereco.Id = Guid.NewGuid();
                endereco.PessoaId = pessoaId;

                _context.Enderecos.Add(endereco);
                await _context.SaveChangesAsync();
                
                return Created(endereco.Id.ToString(), endereco);
            }

            [HttpPatch("{idEndereco}")]
            public async Task<IActionResult> UpdateEndereco(Guid idEndereco, [FromBody] EnderecoRequest request)
            {
                var endereco = await _context.Enderecos.FindAsync(idEndereco);

                if (endereco == null)
                {
                    return NotFound();
                }

                _mapper.Map(request, endereco);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpPatch("principal/{idEndereco}")]
            public async Task<IActionResult> UpdateMakeEnderecoPrincipal(Guid idEndereco)
            {
                var endereco = await _context.Enderecos.FindAsync(idEndereco);
                if (endereco == null)
                {
                    return NotFound();
                }

                var enderecos = await _context.Enderecos.Where(e => e.PessoaId == endereco.PessoaId).ToListAsync();
                foreach (var e in enderecos)
                {
                    e.IsPrincipal = false;
                }

                endereco.IsPrincipal = true;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{idEndereco}")]
            public async Task<IActionResult> DeleteEndereco(Guid idEndereco)
            {
                var endereco = await _context.Enderecos.FindAsync(idEndereco);

                if (endereco == null)
                {
                    return NotFound();
                }

                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
                return NoContent();
            }


        }
}