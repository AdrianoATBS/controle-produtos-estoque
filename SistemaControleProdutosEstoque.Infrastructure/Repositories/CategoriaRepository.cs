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
    public void AdicionarCategoria(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
    }

    public void AtualizarCategoria(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        _context.SaveChanges();
    }

    public void DeletarCategoria(Guid id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        if (categoria != null)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
     }

    public bool ExisteCategoriaComNome(string nome)
    {
       return  _context.Categorias.Any(c => c.Nome == nome);
    
    }



    public async Task<IEnumerable<Categoria>> ObterTodasCategoriasAsync()
    {
       return await _context.Categorias.ToListAsync();
    }

   

    async Task<Categoria?> ICategoriaRepository.ObterCategoriaIdAsync(Guid id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }
}
