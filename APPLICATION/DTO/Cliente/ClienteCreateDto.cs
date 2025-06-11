using System.ComponentModel.DataAnnotations;
using APPLICATION.DTO.Cliente;

namespace APPLICATION.DTO;

public class ClienteCreateDto
{
    [Required, StringLength(100)] public string Nome { get; set; }

    [StringLength(200)] public string Endereco { get; set; }

    [Required, EmailAddress] public string Email { get; set; }

    [Phone] public string Telefone { get; set; }

    [Required, MinLength(6)] public string Senha { get; set; }


    public static INFRA.Models.Cliente ToEntity(ClienteCreateDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Cliente
        {
            Nome = dto.Nome,
            Endereco = dto.Endereco,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Senha = dto.Senha
        };
    }

    public static ClienteCreateDto ToDto(INFRA.Models.Cliente entity)
    {
        if (entity == null) return null;
        return new ClienteCreateDto
        {
            Nome = entity.Nome,
            Endereco = entity.Endereco,
            Email = entity.Email,
            Telefone = entity.Telefone,
            Senha = entity.Senha
        };
    }
}