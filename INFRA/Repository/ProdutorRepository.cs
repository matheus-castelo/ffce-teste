using INFRA.Data;
using INFRA.Models;

namespace INFRA.Repository
{
    public class ProdutorRepository : GenericRepository<Produtor>, IProdutorRepository
    {
        public ProdutorRepository(AppDbContext context) : base(context) { }
    }
}