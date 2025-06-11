using APPLICATION.DTO.Carrinho;

namespace APPLICATION.Services;

public interface ICarrinhoService
{
    Task<IEnumerable<CarrinhoDto>> GetAllAsync();
    Task<CarrinhoDto> GetByIdAsync(int id);
    Task<CarrinhoDto> CreateAsync(CarrinhoCreateDto dto);
    Task<CarrinhoDto> UpdateAsync(CarrinhoUpdateDto dto);
    Task DeleteAsync(int id);
}