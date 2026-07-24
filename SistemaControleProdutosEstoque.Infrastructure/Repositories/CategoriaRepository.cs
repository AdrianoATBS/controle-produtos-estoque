using Microsoft.EntityFrameworkCore;
using SistemaControleProdutosEstoque.Domain.Entities;
using SistemaControleProdutosEstoque.Domain.Interfaces;
using SistemaControleProdutosEstoque.Infrastructure.Data;

namespace SistemaControleProdutosEstoque.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ApplicationDbContext _context;
    public CategoriaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AdicionarCategoriaAsync(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarCategoriaAsync(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarCategoriaAsync(Guid id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        if (categoria != null)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
     }

    public async Task<bool> ExisteCategoriaComNomeAsync(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome)) return false;

        return await _context.Categorias.AnyAsync(c => c.Nome.ToLower() == nome.ToLower());

    }

    public async Task<IEnumerable<Categoria>> ObterTodasCategoriasAsync()
    {
       return await _context.Categorias.ToListAsync();
    }

   

    async Task<Categoria?> ICategoriaRepository.ObterCategoriaIdAsync(Guid id)
    {
        return await _context.Categorias.Include(c => c.Produtos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
