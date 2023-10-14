namespace ApiCSharp.DB;

using Microsoft.EntityFrameworkCore;
using ApiCSharp.domain.DTO;
using ApiTesteTecnico.Domain.DTO;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Boleto> Boletos { get; set; }
    public DbSet<Banco> Bancos { get; set; }
}