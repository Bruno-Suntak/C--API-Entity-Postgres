using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiCSharp.domain.DTO;
using ApiCSharp.DB;
using ApiTesteTecnico.Domain.DTO;

namespace Controller.Bancos
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public BancoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
            if (banco == null)
            {
                return BadRequest("Dados inválidos.");
            }

            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBanco), new { codigobanco = banco.CodigoBanco }, banco);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBancos()
        {
            var bancos = await _context.Bancos.ToListAsync();

            if (bancos == null || bancos.Count == 0)
            {
                return NotFound();
            }

            return Ok(bancos);
        }

        [HttpGet("CodigoBanco/{codigobanco}")]
        public async Task<ActionResult<Banco>> GetBanco(string codigobanco)
        {
            var banco = await _context.Bancos
                .Where(b => b.CodigoBanco == codigobanco)
                .FirstOrDefaultAsync();

            if (banco == null)
            {
                return NotFound();
            }

            return banco;
        }

    }

}