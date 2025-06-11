using System.ComponentModel.DataAnnotations;

namespace APPLICATION.DTO.Cliente;

public class ClienteUpdateDto
{
    [Required]
    public int Id { get; set; }
        
    [StringLength(100)]
    public string Nome { get; set; }
        
    [StringLength(200)]
    public string Endereco { get; set; }
        
    [EmailAddress]
    public string Email { get; set; }
        
    [Phone]
    public string Telefone { get; set; }
        
    [MinLength(6)]
    public string Senha { get; set; }
    
    public static INFRA.Models.Cliente ToEntity(ClienteUpdateDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Cliente
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Endereco = dto.Endereco,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Senha = dto.Senha
        };
    }

    public static ClienteUpdateDto ToDto(INFRA.Models.Cliente entity)
    {
        if (entity == null) return null;
        return new ClienteUpdateDto
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Endereco = entity.Endereco,
            Email = entity.Email,
            Telefone = entity.Telefone,
            Senha = entity.Senha
        };

    }
}