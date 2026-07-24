using Microsoft.EntityFrameworkCore;
using SistemaControleProdutosEstoque.Domain.Entities;
using SistemaControleProdutosEstoque.Domain.Interfaces;
using SistemaControleProdutosEstoque.Infrastructure.Data;

namespace SistemaControleProdutosEstoque.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;
    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AdicionarProdutoAsync(Produto produto)
    {
       _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarProdutoAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarProdutoAsync(Guid id)
    {
        var produtos = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        if(produtos != null)
        {
            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();
        }
       
    }

    public async Task<bool> ExisteProdutoComNomeAsync(string nome)
    {
        if(string.IsNullOrWhiteSpace(nome)) return false;
        return await _context.Produtos.AnyAsync(p => p.Nome.ToLower() == nome.ToLower());
    }

    public async Task<bool> ExisteProdutoNaCategoriaAsync(Guid categoriaId)
    {
        return await _context.Produtos.AnyAsync(p => p.CategoriaId == categoriaId);
    }

    public async Task<Produto?> ObterProdutoIdAsync(Guid id)
    {
        return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(Guid categoriaId)
    {
        return await _context.Produtos.Where(p => p.CategoriaId == categoriaId).ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPorNomeAsync(string nome)
    {
        return await _context.Produtos.Where(p => p.Nome.Contains(nome)).ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterTodosOsProdutosAsync()
    {
       return await _context.Produtos.ToListAsync();
    }
}
