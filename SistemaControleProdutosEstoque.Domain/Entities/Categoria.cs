namespace SistemaControleProdutosEstoque.Domain.Entities;

public class Categoria
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; private set; }
    private Categoria() { }
    private Categoria(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Ativo = true;
        DataCriacao = DateTime.UtcNow;
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
    
    public void CategoriaDesativada()
    {
        if(!Ativo)
            throw new InvalidOperationException("A categoria já está desativada.");
    Ativo = false;
    }
    
    public void CategoriaAtivada()
    {
        if(Ativo)
            throw new InvalidOperationException("A categoria já está ativa.");
        Ativo = true;
    }
   
    
}
