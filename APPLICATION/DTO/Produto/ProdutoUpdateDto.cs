using System.ComponentModel.DataAnnotations;

namespace APPLICATION.DTO.Produto;

public class ProdutoUpdateDto
{
    [Required] public int ProdutoId { get; set; }

    [StringLength(200)] public string NomeProduto { get; set; }

    public string Quantidade { get; set; }

    public decimal? Preco { get; set; }

    public int? ProdutorId { get; set; }

    public IEnumerable<string> ImagensBase64 { get; set; }

    public static INFRA.Models.Produto ToEntity(ProdutoUpdateDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Produto
        {
            ProdutoId = dto.ProdutoId,
            NomeProduto = dto.NomeProduto,
            Quantidade = dto.Quantidade,
            Preco = dto.Preco ?? 0m,
            ProdutorId = dto.ProdutorId ?? 0,
            Imagens = dto.ImagensBase64?
                .Select(Convert.FromBase64String)
                .ToList()
        };
    }

    public static ProdutoUpdateDto ToDto(INFRA.Models.Produto entity)
    {
        if (entity == null) return null;
        return new ProdutoUpdateDto
        {
            ProdutoId = entity.ProdutoId,
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