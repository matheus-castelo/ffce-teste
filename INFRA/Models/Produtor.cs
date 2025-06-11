using System.ComponentModel.DataAnnotations;

namespace INFRA.Models
{
    public class Produtor : BaseModel
    {
        public string Descricao { get; set; }

        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        public string Cnpj { get; set; }  // Adicionando validação de CNPJ
    }
}