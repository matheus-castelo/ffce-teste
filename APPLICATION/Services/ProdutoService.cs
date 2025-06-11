using APPLICATION.DTO.Produto;
using INFRA.Repository;

namespace APPLICATION.Services;

public class ProdutoService
{
    private readonly IUnitOfWork _uow;

    public ProdutoService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
    {
        var entities = await _uow.Produtos.GetAllAsync();
        var dtos = entities.Select(ProdutoDto.ToDto);
        return dtos;
    }

    public async Task<ProdutoDto> GetByIdAsync(int id)
    {
        var entity = await _uow.Produtos.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Produto com Id={id} não encontrado.");
        return ProdutoDto.ToDto(entity);
    }

    public async Task<ProdutoDto> CreateAsync(ProdutoCreateDto dto)
    {
        var entity = ProdutoCreateDto.ToEntity(dto);
        await _uow.Produtos.AddAsync(entity);
        await _uow.CommitAsync();
        return ProdutoDto.ToDto(entity);
    }

    public async Task<ProdutoDto> UpdateAsync(ProdutoUpdateDto dto)
    {
        var existing = await _uow.Produtos.GetByIdAsync(dto.ProdutoId);
        if (existing == null)
            throw new KeyNotFoundException($"Produto com Id={dto.ProdutoId} não encontrado.");
        var updated = ProdutoUpdateDto.ToEntity(dto);
        _uow.Produtos.UpdateAsync(updated);
        await _uow.CommitAsync();
        return ProdutoDto.ToDto(updated);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _uow.Produtos.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Produto com Id={id} não encontrado.");
        _uow.Produtos.DeleteAsync(entity);
        await _uow.CommitAsync();
    }
}