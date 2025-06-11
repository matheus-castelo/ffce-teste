using APPLICATION.DTO.Produto;

namespace APPLICATION.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> GetAllAsync();
    Task<ProdutoDto> GetByIdAsync(int id);
    Task<ProdutoDto> CreateAsync(ProdutoCreateDto dto);
    Task<ProdutoDto> UpdateAsync(ProdutoUpdateDto dto);
    Task DeleteAsync(int id);
}