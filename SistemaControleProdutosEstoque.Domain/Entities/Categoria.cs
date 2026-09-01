namespace SistemaControleProdutosEstoque.Domain.Entities;

public class Categoria
{
    private readonly List<Produto> _produtos = new();
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public IReadOnlyCollection<Produto> Produtos => _produtos.AsReadOnly();
    private Categoria() { }
    private Categoria(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Ativo = true;
        DataCriacao = DateTime.Now;
    }
    public static Categoria Criar(string nome)
    {
        ValidarNome(nome);
        return new Categoria(nome);
    }

    private static void ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome da categoria é obrigatório.");
                
    }
    public void AlterarNome(string novoNome)
    {
        ValidarNome(novoNome);
        if(!Ativo)
            throw new InvalidOperationException("Não é possível alterar o nome de uma categoria desativada.");

        if (Normalizar(novoNome) == Normalizar(Nome))
            throw new InvalidOperationException("O novo nome da categoria é igual ao nome atual.");

        Nome = novoNome;
    }

    public void Desativar()
    {
        if(!Ativo)
            throw new InvalidOperationException("A categoria já está desativada.");
        if(Produtos.Any(p => p.Ativo))
            throw new InvalidOperationException("Não é possível desativar uma categoria que possui produtos ativos.");))
        Ativo = false;
    }
    
    public void Ativar()
    {
        if(Ativo)
            throw new InvalidOperationException("A categoria já está ativa.");
        Ativo = true;
    }
   
    private static string Normalizar(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            return string.Empty;
        return valor.Trim().ToLower();
    }
    
}
