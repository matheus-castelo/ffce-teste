using APPLICATION.DTO;
using APPLICATION.DTO.Cliente;
using INFRA.Repository;

namespace APPLICATION.Services;

public class ClienteService
{
    private readonly IUnitOfWork _uow;

    public ClienteService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var entities = await _uow.Clientes.GetAllAsync();
        var dtos = new List<ClienteDto>();
        foreach (var e in entities)
            dtos.Add(ClienteDto.ToDto(e));
        return dtos;
    }

    public async Task<ClienteDto> GetByIdAsync(int id)
    {
        var entity = await _uow.Clientes.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Cliente com Id={id} não encontrado.");
        return ClienteDto.ToDto(entity);
    }

    public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto)
    {
        var entity = ClienteCreateDto.ToEntity(dto);
        await _uow.Clientes.AddAsync(entity);
        await _uow.CommitAsync();
        return ClienteDto.ToDto(entity);
    }

    public async Task<ClienteDto> UpdateAsync(ClienteUpdateDto dto)
    {
        var existing = await _uow.Clientes.GetByIdAsync(dto.Id);
        if (existing == null)
            throw new KeyNotFoundException($"Cliente com Id={dto.Id} não encontrado.");
        var updated = ClienteUpdateDto.ToEntity(dto);
        _uow.Clientes.UpdateAsync(updated);
        await _uow.CommitAsync();
        return ClienteDto.ToDto(updated);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _uow.Clientes.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Cliente com Id={id} não encontrado.");
        _uow.Clientes.DeleteAsync(entity);
        await _uow.CommitAsync();
    }
}