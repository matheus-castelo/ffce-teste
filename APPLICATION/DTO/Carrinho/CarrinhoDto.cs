namespace APPLICATION.DTO.Carrinho;

public class CarrinhoDto
{
    public int CarrinhoId { get; set; }
    public int ClienteId { get; set; }
    public IEnumerable<ProdutoResumoDto> Produtos { get; set; }
    public decimal Total { get; set; }
    
    public static CarrinhoDto ToDto(INFRA.Models.Carrinho entity)
    {
        if (entity == null) return null;
        return new CarrinhoDto
        {
            CarrinhoId = entity.CarrinhoId,
            ClienteId = entity.ClienteId,
            Total = entity.Total,
            Produtos = entity.Produtos?
                .Select(p => new ProdutoResumoDto
                {
                    ProdutoId = p.ProdutoId,
                    NomeProduto = p.NomeProduto,
                    Preco = p.Preco
                })
                .ToList()
        };
    }

    public static INFRA.Models.Carrinho ToEntity(CarrinhoDto dto)
    {
        if (dto == null) return null;
        var c = new INFRA.Models.Carrinho
        {
            CarrinhoId = dto.CarrinhoId,
            ClienteId = dto.ClienteId
        };
        if (dto.Produtos != null)
        {
            foreach (var pr in dto.Produtos)
            {
                c.Produtos.Add(new INFRA.Models.Produto
                {
                    ProdutoId = pr.ProdutoId,
                    NomeProduto = pr.NomeProduto,
                    Preco = pr.Preco
                });
            }
            c.AtualizarTotal();
        }
        return c;
    }
}
