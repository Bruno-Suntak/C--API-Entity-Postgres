using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiCSharp.domain.DTO;
using ApiCSharp.DB;

namespace Controller.Boletos
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public BoletoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Boleto>> PostBoleto(Boleto boleto)
        {
            if (boleto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoleto), new { id = boleto.Id }, boleto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoleto(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);

            if (boleto == null)
            {
                return NotFound();
            }

            // Verificar se a data de vencimento já passou
            if (DateTime.Now > DateTime.Parse(boleto.DataVencimento))
            {
                // Calcular juros com base no percentual de juros do banco
                var banco = await _context.Bancos.FindAsync(boleto.BancoId);
                if (banco != null)
                {
                    decimal valorOriginal = boleto.Valor;
                    decimal percentualJuros = banco.PercentualJuros;
                    decimal juros = valorOriginal * (percentualJuros / 100);
                    boleto.Valor = valorOriginal + juros;
                }
            }

            return boleto;
        }

    }
}