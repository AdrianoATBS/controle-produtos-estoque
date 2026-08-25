using FluentValidation;
using SistemaControleProdutosEstoque.Application.Exceptions;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.Responses.Estoque;
using SistemaControleProdutosEstoque.Application.Validators.Estoque;
using SistemaControleProdutosEstoque.Domain.Entities;
using SistemaControleProdutosEstoque.Domain.Enums;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;

public class AdicionarEstoqueUseCase : IAdicionarEstoqueUseCase
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly AdicionarEstoqueRequestValidator _validator;

    public AdicionarEstoqueUseCase(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository,
        IProdutoRepository produtoRepository, AdicionarEstoqueRequestValidator validator)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        _produtoRepository = produtoRepository;
        _validator = validator;
    }

    public async Task<AdicionarEstoqueResponse> Executar(AdicionarEstoqueRequest request)
    {
        var resultadoValidacao= await _validator.ValidateAsync(request);
        if (!resultadoValidacao.IsValid)    
                throw new ValidationException(resultadoValidacao.Errors);

        var produto = await _produtoRepository.ObterProdutoIdAsync(request.ProdutoId);
        if (produto == null)
            throw new NotFoundException("Produto não encontrado");
     
        ProcessarMovimentacaoProduto(produto, request.TipoEstoque, request.Quantidade);

        var movimentacao = MovimentacaoEstoque.Criar(produto, request.TipoEstoque,
            request.Quantidade);

        await _produtoRepository.AtualizarProdutoAsync(produto);
        await _movimentacaoEstoqueRepository.RegistrarMovimentacaoEstoqueAsync(movimentacao);

        return new AdicionarEstoqueResponse
        {
            Id = movimentacao.Id,
            Quantidade = movimentacao.Quantidade,
            QuantidadeAtual = produto.QuantidadeEstoque.ToString(),
            TipoEstoque = movimentacao.Tipo,
            DataCriacao = movimentacao.DataMovimentacao.ToString("dd/MM/yyyy HH:mm:ss")
        };
    }
    private void ProcessarMovimentacaoProduto(Produto produto, TipoMovimentacao
         tipo, int quantidade)
    {
        if (tipo == TipoMovimentacao.Entrada)
        {
            produto.AdicionarEstoque(quantidade);
        }
        else if (tipo == TipoMovimentacao.Saida)
        {
            produto.RemoverEstoque(quantidade);
        }
        else
        {
            throw new ArgumentException("Tipo de movimentação inválido");
        }
    }
}
