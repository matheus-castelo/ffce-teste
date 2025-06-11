using APPLICATION.DTO;
using APPLICATION.DTO.Cliente;

namespace APPLICATION.Services;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetAllAsync();
    Task<ClienteDto> GetByIdAsync(int id);
    Task<ClienteDto> CreateAsync(ClienteCreateDto dto);
    Task<ClienteDto> UpdateAsync(ClienteUpdateDto dto);
    Task DeleteAsync(int id);
}