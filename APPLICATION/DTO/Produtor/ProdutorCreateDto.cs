using System.ComponentModel.DataAnnotations;

namespace APPLICATION.DTO.Produtor;

public class ProdutorCreateDto
{
    [Required, StringLength(100)]
    public string Nome { get; set; }
        
    [StringLength(200)]
    public string Endereco { get; set; }
        
    [Required, EmailAddress]
    public string Email { get; set; }
        
    [Phone]
    public string Telefone { get; set; }
        
    [StringLength(500)]
    public string Descricao { get; set; }
        
    [Required, RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")]
    public string Cnpj { get; set; }
        
    [Required, MinLength(6)]
    public string Senha { get; set; }
    
    
    public static INFRA.Models.Produtor ToEntity(ProdutorCreateDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Produtor
        {
            Nome = dto.Nome,
            Endereco = dto.Endereco,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Descricao = dto.Descricao,
            Cnpj = dto.Cnpj,
            Senha = dto.Senha
        };
    }

    public static ProdutorCreateDto ToDto(INFRA.Models.Produtor entity)
    {
        if (entity == null) return null;
        return new ProdutorCreateDto
        {
            Nome = entity.Nome,
            Endereco = entity.Endereco,
            Email = entity.Email,
            Telefone = entity.Telefone,
            Descricao = entity.Descricao,
            Cnpj = entity.Cnpj,
            Senha = entity.Senha
        };
    }
}