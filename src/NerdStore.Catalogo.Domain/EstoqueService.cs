using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.DomainObjects.DTO;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        #region Private Fields

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProdutoRepository _produtoRepository;

        #endregion Private Fields

        #region Public Constructors

        public EstoqueService(IMediatorHandler bus, IProdutoRepository produtoRepository)
        {
            _mediatorHandler = bus;
            _produtoRepository = produtoRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            if (!await DebitarItemEstoque(produtoId, quantidade)) return false;

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> DebitarListaProdutosPedido(ListaProdutosPedido lista)
        {
            foreach (Item item in lista.Itens)
                if (!await DebitarItemEstoque(item.Id, item.Quantidade)) return false;

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporListaProdutosPedido(ListaProdutosPedido lista)
        {
            foreach (Item item in lista.Itens)
                await ReporItemEstoque(item.Id, item.Quantidade);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            bool _sucesso = await ReporItemEstoque(produtoId: produtoId,
                                                   quantidade: quantidade);

            if (!_sucesso) return false;

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> DebitarItemEstoque(Guid produtoId, int quantidade)
        {
            Produto _produto = await _produtoRepository.ObterPorId(produtoId);

            if (_produto == null) return false;

            if (!_produto.PossuiEstoque(quantidade))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(key: "Estoque",
                                                                                  value: $"Produto - {_produto.Nome} sem estoque"));
                return false;
            }

            _produto.DebitarEstoque(quantidade);

            // TODO: 10 pode ser parametrizavel em arquivo de configuração
            if (_produto.QuantidadeEstoque < 10)
                await _mediatorHandler.PublicarDomainEvent(new ProdutoAbaixoEstoqueEvent(aggregateId: _produto.Id,
                                                                                         quantidadeRestante: _produto.QuantidadeEstoque));

            _produtoRepository.Atualizar(_produto);

            return true;
        }

        private async Task<bool> ReporItemEstoque(Guid produtoId, int quantidade)
        {
            Produto _produto = await _produtoRepository.ObterPorId(produtoId);

            if (_produto == null) return false;

            _produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(_produto);

            return true;
        }

        #endregion Private Methods
    }
}
