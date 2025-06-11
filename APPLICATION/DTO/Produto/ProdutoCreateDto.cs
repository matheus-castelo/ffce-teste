using System.ComponentModel.DataAnnotations;

namespace APPLICATION.DTO.Produto;

public class ProdutoCreateDto
{
    [Required, StringLength(200)] public string NomeProduto { get; set; }

    [Required] public string Quantidade { get; set; }

    [Required] public decimal Preco { get; set; }

    [Required] public int ProdutorId { get; set; }

    public IEnumerable<string> ImagensBase64 { get; set; }

    public static INFRA.Models.Produto ToEntity(ProdutoCreateDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Produto
        {
            NomeProduto = dto.NomeProduto,
            Quantidade = dto.Quantidade,
            Preco = dto.Preco,
            ProdutorId = dto.ProdutorId,
            Imagens = dto.ImagensBase64?
                .Select(Convert.FromBase64String)
                .ToList()
        };
    }

    public static ProdutoCreateDto ToDto(INFRA.Models.Produto entity)
    {
        if (entity == null) return null;
        return new ProdutoCreateDto
        {
            NomeProduto = entity.NomeProduto,
            Quantidade = entity.Quantidade,
            Preco = entity.Preco,
            ProdutorId = entity.ProdutorId,
            ImagensBase64 = entity.Imagens?
                .Select(bytes => Convert.ToBase64String(bytes))
                .ToList()
        };
    }
}