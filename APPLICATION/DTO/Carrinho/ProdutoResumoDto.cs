namespace APPLICATION.DTO.Carrinho;

public class ProdutoResumoDto
{
    public int ProdutoId { get; set; }
    public string NomeProduto { get; set; }
    public decimal Preco { get; set; }

    public static ProdutoResumoDto ToDto(INFRA.Models.Produto entity)
    {
        if (entity == null) return null;
        return new ProdutoResumoDto
        {
            ProdutoId = entity.ProdutoId,
            NomeProduto = entity.NomeProduto,
            Preco = entity.Preco
        };
    }

    public static INFRA.Models.Produto ToEntity(ProdutoResumoDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Produto
        {
            ProdutoId = dto.ProdutoId,
            NomeProduto = dto.NomeProduto,
            Preco = dto.Preco
        };
    }
}