namespace APPLICATION.DTO.Produto;

public class ProdutoDto
{
    public int ProdutoId { get; set; }
    public string NomeProduto { get; set; }
    public string Quantidade { get; set; }
    public decimal Preco { get; set; }
    public int ProdutorId { get; set; }
    public string ProdutorNome { get; set; }
    public IEnumerable<string> ImagensBase64 { get; set; }

    public static ProdutoDto ToDto(INFRA.Models.Produto entity)
    {
        if (entity == null) return null;

        return new ProdutoDto
        {
            ProdutoId = entity.ProdutoId,
            NomeProduto = entity.NomeProduto,
            Quantidade = entity.Quantidade,
            Preco = entity.Preco,
            ProdutorId = entity.ProdutorId,
            ProdutorNome = entity.Produtor?.Nome,
            ImagensBase64 = entity.Imagens?
                .Select(bytes => Convert.ToBase64String(bytes))
                .ToList()
        };
    }


    public static INFRA.Models.Produto ToEntity(ProdutoDto dto)
    {
        if (dto == null) return null;
        return new INFRA.Models.Produto
        {
            ProdutoId = dto.ProdutoId,
            NomeProduto = dto.NomeProduto,
            Quantidade = dto.Quantidade,
            Preco = dto.Preco,
            ProdutorId = dto.ProdutorId,
            Imagens = dto.ImagensBase64?
                .Select(b64 => Convert.FromBase64String(b64))
                .ToList()
        };
    }
}