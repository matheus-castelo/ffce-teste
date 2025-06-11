using APPLICATION.DTO.Produtor;
using INFRA.Repository;

namespace APPLICATION.Services;

public class ProdutorService : IProdutorService
{
    private readonly IUnitOfWork _uow;

    public ProdutorService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<ProdutorDto>> GetAllAsync()
    {
        var entities = await _uow.Produtores.GetAllAsync();
        var dtos = new List<ProdutorDto>();
        foreach (var e in entities)
            dtos.Add(ProdutorDto.ToDto(e));
        return dtos;
    }

    public async Task<ProdutorDto> GetByIdAsync(int id)
    {
        var entity = await _uow.Produtores.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Produtor com Id={id} não encontrado.");
        return ProdutorDto.ToDto(entity);
    }

    public async Task<ProdutorDto> CreateAsync(ProdutorCreateDto dto)
    {
        var entity = ProdutorCreateDto.ToEntity(dto);
        await _uow.Produtores.AddAsync(entity);
        await _uow.CommitAsync();
        return ProdutorDto.ToDto(entity);
    }

    public async Task<ProdutorDto> UpdateAsync(ProdutorUpdateDto dto)
    {
        var existing = await _uow.Produtores.GetByIdAsync(dto.Id);
        if (existing == null)
            throw new KeyNotFoundException($"Produtor com Id={dto.Id} não encontrado.");
        var updated = ProdutorUpdateDto.ToEntity(dto);
        _uow.Produtores.UpdateAsync(updated);
        await _uow.CommitAsync();
        return ProdutorDto.ToDto(updated);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _uow.Produtores.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Produtor com Id={id} não encontrado.");
        _uow.Produtores.DeleteAsync(entity);
        await _uow.CommitAsync();
    }
}