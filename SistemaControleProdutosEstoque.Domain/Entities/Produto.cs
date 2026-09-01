namespace SistemaControleProdutosEstoque.Domain.Entities;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;
    public decimal Preco { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; private set; }

    private Produto() { Categoria = null!; }
    private Produto(string nome, string descricao, decimal preco,
        int quantidadeEstoque, Categoria categoria)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        CategoriaId = categoria.Id;
        Categoria = categoria;
        Ativo = true;
        DataCriacao = DateTime.Now;
    }
    public static Produto Criar(string nome, string descricao, decimal preco,
        int quantidadeEsotque, Categoria categoria)
    {
        ValidarNome(nome);
        ValidarPreco(preco);
        ValidarQuantidadeEstoque(quantidadeEsotque);
        ValidarCategoria(categoria);

        return new Produto(nome, descricao, preco, quantidadeEsotque, categoria);
    }

    private static void ValidarNome(string nome)
    {
        if(string.IsNullOrWhiteSpace(nome))
            throw new ArgumentNullException("O nome do produto é obrigatório.");
    }
    private static void ValidarPreco(decimal preco)
    {
        if (preco <= 0)
            throw new ArgumentException("O preçõ do produto deve ser maior que zero.");
    }
    private static void ValidarQuantidadeEstoque(int quantidade)
    {
        if(quantidade < 0)
            throw new ArgumentException("A quantidade em estoque não pode ser negativa.");
    }
    private static void ValidarCategoria(Categoria categoria)
    {
         if(categoria == null)
                throw new ArgumentNullException("A categoria do produto é obrigatória.");
         if(!categoria.Ativo)
            throw new InvalidOperationException("Não é possível associar um produto a uma categoria desativada.");
    }
    public void Desativar()
    {
        if(!Ativo)
               throw new InvalidOperationException("O produto já está desativado.");
        
        Ativo = false;
    }
    public void Ativar()
    {
        if(Ativo)
            throw new InvalidOperationException("O produto já está ativado.");
        Ativo = true;
    }
    public void AlterarDados(string novoNome, string novaDescricao, decimal novoPreco)
    {
        ValidarNome(novoNome);
        ValidarPreco(novoPreco);

        Nome = novoNome;
        Descricao = novaDescricao;
        Preco = novoPreco;
    }
    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");
      
        QuantidadeEstoque += quantidade;
    }
    public void RemoverEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");
        if (QuantidadeEstoque < quantidade)
            throw new InvalidOperationException("Estoque insuficiente");
        QuantidadeEstoque -= quantidade;
    }
  

}
