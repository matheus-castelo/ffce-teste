using INFRA.Data;
using INFRA.Models;

namespace INFRA.Repository
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }
    }
}