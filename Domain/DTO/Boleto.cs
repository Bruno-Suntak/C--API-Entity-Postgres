using ApiTesteTecnico.Domain.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCSharp.domain.DTO
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DataValidaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || !(value is string))
            {
                return false;
            }

            string dataString = (string)value;
            if (DateTime.TryParseExact(dataString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                return true;
            }

            return false;
        }
    }


    public class Boleto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome do Pagador é obrigatório.")]
        public string NomePagador { get; set; }
        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
        public string CPF_CNPJ { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "O campo Data do Vencimento é obrigatório.")]
        [DataValida(ErrorMessage = "Formato de data inválido. Use o formato dd/MM/yyyy.")]
        public string DataVencimento { get; set; }
        public string Observacao { get; set; }
        [Required(ErrorMessage = "O campo BancoId é obrigatório.")]
        public int BancoId { get; set; }
    }
}