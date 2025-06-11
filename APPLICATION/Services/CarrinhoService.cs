using APPLICATION.DTO.Carrinho;
using INFRA.Repository;

namespace APPLICATION.Services;

public class CarrinhoService : ICarrinhoService
{
    private readonly IUnitOfWork _uow;

    public CarrinhoService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<CarrinhoDto>> GetAllAsync()
    {
        var entities = await _uow.Carrinhos.GetAllAsync();
        return entities.Select(CarrinhoDto.ToDto);
    }

    public async Task<CarrinhoDto> GetByIdAsync(int id)
    {
        var entity = await _uow.Carrinhos.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Carrinho com Id={id} não encontrado.");
        return CarrinhoDto.ToDto(entity);
    }

    public async Task<CarrinhoDto> CreateAsync(CarrinhoCreateDto dto)
    {
        var entity = CarrinhoCreateDto.ToEntity(dto);
        await _uow.Carrinhos.AddAsync(entity);
        await _uow.CommitAsync();
        return CarrinhoDto.ToDto(entity);
    }

    public async Task<CarrinhoDto> UpdateAsync(CarrinhoUpdateDto dto)
    {
        var existing = await _uow.Carrinhos.GetByIdAsync(dto.CarrinhoId);
        if (existing == null)
            throw new KeyNotFoundException($"Carrinho com Id={dto.CarrinhoId} não encontrado.");
        var updated = CarrinhoUpdateDto.ToEntity(dto);
        _uow.Carrinhos.UpdateAsync(updated);
        await _uow.CommitAsync();
        return CarrinhoDto.ToDto(updated);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _uow.Carrinhos.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Carrinho com Id={id} não encontrado.");
        _uow.Carrinhos.DeleteAsync(entity);
        await _uow.CommitAsync();
    }
}
