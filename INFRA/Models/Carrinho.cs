namespace INFRA.Models
{
    public class Carrinho
    {
        public int CarrinhoId { get; set; }
        public int ClienteId { get; set; }  
        public List<Produto> Produtos { get; set; }  
        public decimal Total { get; set; }  

        public Carrinho()
        {
            Produtos = new List<Produto>();  
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            var produtoExistente = Produtos.Find(p => p.ProdutoId == produto.ProdutoId);
            
            if (produtoExistente != null)
            {
                
            }
            else
            {
                for (int i = 0; i < quantidade; i++)
                {
                    Produtos.Add(produto);  
                    Total += produto.Preco;  
                }
            }
        }

        public void AtualizarTotal()
        {
            Total = 0;
            foreach (var produto in Produtos)
            {
                Total += produto.Preco;  
            }
        }
    }
}