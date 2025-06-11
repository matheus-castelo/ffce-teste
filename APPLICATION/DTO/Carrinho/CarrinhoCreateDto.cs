using System.ComponentModel.DataAnnotations;

namespace APPLICATION.DTO.Carrinho;

public class CarrinhoCreateDto
{
    [Required] public int ClienteId { get; set; }

    [Required] public IEnumerable<int> ProdutoIds { get; set; }

    public static INFRA.Models.Carrinho ToEntity(CarrinhoCreateDto dto)
    {
        if (dto == null) return null;
        var c = new INFRA.Models.Carrinho { ClienteId = dto.ClienteId };
        if (dto.ProdutoIds != null)
        {
            // Assumindo que você irá carregar as entidades Produto antes de chamar este método
            foreach (var pid in dto.ProdutoIds)
                c.Produtos.Add(new INFRA.Models.Produto { ProdutoId = pid });
            c.AtualizarTotal();
        }

        return c;
    }

    public static CarrinhoCreateDto ToDto(INFRA.Models.Carrinho entity)
    {
        if (entity == null) return null;
        return new CarrinhoCreateDto
        {
            ClienteId = entity.ClienteId,
            ProdutoIds = entity.Produtos?.Select(p => p.ProdutoId).ToList()
        };
    }
}