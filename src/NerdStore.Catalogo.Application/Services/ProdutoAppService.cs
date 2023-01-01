using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        #region Private Fields

        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        #endregion Private Fields

        #region Public Constructors

        public ProdutoAppService(IEstoqueService estoqueService,
                                 IMapper mapper,
                                 IProdutoRepository produtoRepository)
        {
            _estoqueService = estoqueService;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _produtoRepository.ObterCategorias());
        }

        public async Task AdicionarProduto(ProdutoViewModel produtoViewModel)
        {
            _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoViewModel produtoViewModel)
        {
            _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao debitar estoque");

            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao repor estoque");

            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _estoqueService?.Dispose();
        }

        #endregion Public Methods
    }
}
