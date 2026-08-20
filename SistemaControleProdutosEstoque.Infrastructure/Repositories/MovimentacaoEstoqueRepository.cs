using Microsoft.EntityFrameworkCore;
using SistemaControleProdutosEstoque.Domain.Entities;
using SistemaControleProdutosEstoque.Domain.Interfaces;
using SistemaControleProdutosEstoque.Infrastructure.Data;

namespace SistemaControleProdutosEstoque.Infrastructure.Repositories;

public class MovimentacaoEstoqueRepository : IMovimentacaoEstoqueRepository
{
    private readonly ApplicationDbContext _context;
    public MovimentacaoEstoqueRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<MovimentacaoEstoque?> ObterMovimentacaoAsync(Guid id)
    {
        return await _context.MovimentacoesEstoque.Include(p => p.Produto)
            .FirstOrDefaultAsync(mov => mov.Id == id);
    }

    public async Task<IEnumerable<MovimentacaoEstoque>> ObterTodasMovimentacoesAsync()
    {
        return await _context.MovimentacoesEstoque.Include(p => p.Produto)
            .ToListAsync();
    }

    public async Task<MovimentacaoEstoque?> ObterUltimaMovimentacaoPorProdutoAsync(Guid produtoId)
    {
        return await _context.MovimentacoesEstoque.Include(p => p.Produto)
            .Where(mov => mov.ProdutoId == produtoId)
            .OrderByDescending(mov => mov.DataMovimentacao)
            .FirstOrDefaultAsync();
    }

    public async Task RegistrarMovimentacaoEstoqueAsync(MovimentacaoEstoque movimentacaoEstoque)
    {
        _context.MovimentacoesEstoque.Add(movimentacaoEstoque);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<MovimentacaoEstoque>> ObterMovimentacaoDoProdutoIdAsync(Guid produtoId)
    {
        return await _context.MovimentacoesEstoque.Include(p => p.Produto)
            .Where(mov => mov.ProdutoId == produtoId)
            .ToListAsync();
    }
    public async Task<IEnumerable<MovimentacaoEstoque>> ObterMovimentacoesPorPeridoAsync(DateOnly dataInicio,
        DateOnly dataFim)
    {
        DateTime InicioConvertido = dataInicio.ToDateTime(TimeOnly.MinValue);
        DateTime FimConvertido = dataFim.ToDateTime(TimeOnly.MaxValue);

        return await _context.MovimentacoesEstoque.Include(p => p.Produto)
            .Where(m => m.DataMovimentacao >= InicioConvertido && m.DataMovimentacao <= FimConvertido)
            .ToListAsync();
    }

}
