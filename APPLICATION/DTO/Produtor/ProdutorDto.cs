namespace APPLICATION.DTO.Produtor;

public class ProdutorDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Descricao { get; set; }
    public string Cnpj { get; set; }

    public static ProdutorDto ToDto(INFRA.Models.Produtor entity)
    {
        if (entity == null) return null;
        return new ProdutorDto
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Endereco = entity.Endereco,
            Email = entity.Email,
            Telefone = entity.Telefone,
            Descricao = entity.Descricao,
            Cnpj = entity.Cnpj
        };
    }

    public static INFRA.Models.Produtor ToEntity(ProdutorDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Produtor
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Endereco = dto.Endereco,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Descricao = dto.Descricao,
            Cnpj = dto.Cnpj
        };
    }
}