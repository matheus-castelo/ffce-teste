using INFRA.Data;

namespace INFRA.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IClienteRepository Clientes { get; }
        public IProdutorRepository Produtores { get; }
        public IProdutoRepository Produtos { get; }
        public ICarrinhoRepository Carrinhos { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Clientes = new ClienteRepository(context);
            Produtores = new ProdutorRepository(context);
            Produtos = new ProdutoRepository(context);
            Carrinhos = new CarrinhoRepository(context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}