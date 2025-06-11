namespace INFRA.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int ProdutorId { get; set; }  // Chave estrangeira explícita
        public Produtor Produtor { get; set; }
        public List<byte[]> Imagens { get; set; }

        public Produto()
        {
            Imagens = new List<byte[]>();
        }
    }
}