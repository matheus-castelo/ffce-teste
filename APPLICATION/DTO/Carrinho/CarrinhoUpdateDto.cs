using System.ComponentModel.DataAnnotations;

namespace APPLICATION.DTO.Carrinho;

public class CarrinhoUpdateDto
{
    [Required]
    public int CarrinhoId { get; set; }
        
    public IEnumerable<int> ProdutoIds { get; set; }
    
    public static INFRA.Models.Carrinho ToEntity(CarrinhoUpdateDto dto)
    {
        if (dto == null) return null;
        var c = new INFRA.Models.Carrinho { CarrinhoId = dto.CarrinhoId };
        if (dto.ProdutoIds != null)
        {
            foreach (var pid in dto.ProdutoIds)
                c.Produtos.Add(new INFRA.Models.Produto { ProdutoId = pid });
            c.AtualizarTotal();
        }
        return c;
    }

    public static CarrinhoUpdateDto ToDto(INFRA.Models.Carrinho entity)
    {
        if (entity == null) return null;
        return new CarrinhoUpdateDto
        {
            CarrinhoId = entity.CarrinhoId,
            ProdutoIds = entity.Produtos?.Select(p => p.ProdutoId).ToList()
        };
}
    
}