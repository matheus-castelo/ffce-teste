namespace INFRA.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository Clientes { get; }
        IProdutorRepository Produtores { get; }
        IProdutoRepository Produtos { get; }
        ICarrinhoRepository Carrinhos { get; }
        Task<int> CommitAsync();
    }
}