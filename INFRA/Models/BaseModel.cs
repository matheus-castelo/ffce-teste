using System.ComponentModel.DataAnnotations;

namespace INFRA.Models;

public class BaseModel
{
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    [Key]
    public int Id { get; set; }
    
}