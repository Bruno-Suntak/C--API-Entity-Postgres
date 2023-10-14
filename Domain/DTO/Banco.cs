using System.ComponentModel.DataAnnotations;

namespace ApiTesteTecnico.Domain.DTO
{
    public class Banco
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome do Banco é obrigatório.")]
        public string NomeBanco { get; set; }
        [Required(ErrorMessage = "O campo Código do Banco é obrigatório.")]
        public string CodigoBanco { get; set; }
        [Required(ErrorMessage = "O campo Percentual de Juros é obrigatório.")]
        public decimal PercentualJuros { get; set; }
    
    }
}
