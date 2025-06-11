using APPLICATION.DTO.Produtor;

namespace APPLICATION.Services;

public interface IProdutorService
{
    Task<IEnumerable<ProdutorDto>> GetAllAsync();
    Task<ProdutorDto> GetByIdAsync(int id);
    Task<ProdutorDto> CreateAsync(ProdutorCreateDto dto);
    Task<ProdutorDto> UpdateAsync(ProdutorUpdateDto dto);
    Task DeleteAsync(int id);
}