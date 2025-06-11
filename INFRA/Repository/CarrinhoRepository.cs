using INFRA.Data;
using INFRA.Models;

namespace INFRA.Repository
{
    public class CarrinhoRepository : GenericRepository<Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(AppDbContext context) : base(context) { }
    }
}