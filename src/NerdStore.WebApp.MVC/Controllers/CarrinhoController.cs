using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Queries;
using NerdStore.Vendas.Application.Queries.ViewModels;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPedidoQueries _pedidoQueries;
        private readonly IProdutoAppService _produtoAppService;

        public CarrinhoController(IMediatorHandler mediatorHandler,
                                  INotificationHandler<DomainNotification> notifications,
                                  IPedidoQueries pedidoQueries,
                                  IProdutoAppService produtoAppService) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _pedidoQueries = pedidoQueries;
            _produtoAppService = produtoAppService;
        }

        [Route("meu-carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
        }

        [HttpPost, AllowAnonymous]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            Catalogo.Application.ViewModels.ProdutoViewModel _produto = await _produtoAppService.ObterPorId(id);

            if (_produto is null)
                return BadRequest();

            if (_produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction(nameof(VitrineController.ProdutoDetalhe), "Vitrine", new { id });
            }

            AdicionarItemPedidoCommand _command = new(clienteId: ClienteId,
                                                      produtoId: _produto.Id,
                                                      nome: _produto.Nome,
                                                      quantidade: quantidade,
                                                      valorUnitario: _produto.Valor);

            await _mediatorHandler.EnviarComando(_command);


            if (OperacaoValida())
                return RedirectToAction(nameof(Index));

            TempData["Erros"] = ObterMensagensErro();
            return RedirectToAction(nameof(VitrineController.ProdutoDetalhe), "Vitrine", new { id });
        }

        [HttpPost]
        [Route("remover-item")]
        public async Task<IActionResult> RemoverItem(Guid id)
        {
            Catalogo.Application.ViewModels.ProdutoViewModel _produto = await _produtoAppService.ObterPorId(id);

            if (_produto is null)
                return BadRequest();

            RemoverItemPedidoCommand _command = new(clienteId: ClienteId,
                                                    produtoId: id);

            await _mediatorHandler.EnviarComando(_command);

            if (OperacaoValida())
                return RedirectToAction(nameof(Index));

            return View(nameof(Index), await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
        }

        [HttpPost]
        [Route("atualizar-item")]
        public async Task<IActionResult> AtualizarItem(Guid id, int quantidade)
        {
            Catalogo.Application.ViewModels.ProdutoViewModel _produto = await _produtoAppService.ObterPorId(id);

            if (_produto is null)
                return BadRequest();

            AtualizarItemPedidoCommand _command = new(clienteId: ClienteId,
                                                      produtoId: id,
                                                      quantidade: quantidade);

            await _mediatorHandler.EnviarComando(_command);

            if (OperacaoValida())
                return RedirectToAction(nameof(Index));

            return View(nameof(Index), await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
        }

        [HttpPost]
        [Route("aplicar-voucher")]
        public async Task<IActionResult> AplicarVoucher(string voucherCodigo)
        {
            AplicarVoucherPedidoCommand _command = new(clienteId: ClienteId,
                                                       codigoVoucher: voucherCodigo);

            await _mediatorHandler.EnviarComando(_command);

            if (OperacaoValida())
                return RedirectToAction(nameof(Index));

            return View(nameof(Index), await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
        }

        [Route("resumo-da-compra")]
        public async Task<IActionResult> ResumoDaCompra()
        {
            return View(await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
        }

        [HttpPost]
        [Route("iniciar-pedido")]
        public async Task<IActionResult> IniciarPedido(CarrinhoViewModel carrinhoViewModel)
        {
            CarrinhoViewModel _carrinho = await _pedidoQueries.ObterCarrinhoCliente(ClienteId);

            IniciarPedidoCommand _command = new(pedidoId: _carrinho.PedidoId,
                                                clienteId: ClienteId,
                                                total: _carrinho.ValorTotal,
                                                nomeCartao: carrinhoViewModel.Pagamento.NomeCartao,
                                                numeroCartao: carrinhoViewModel.Pagamento.NumeroCartao,
                                                expiracaoCartao: carrinhoViewModel.Pagamento.ExpiracaoCartao,
                                                cvvCartao: carrinhoViewModel.Pagamento.CvvCartao);

            await _mediatorHandler.EnviarComando(_command);

            if (OperacaoValida())
                return RedirectToAction(nameof(Index), "Pedido");

            return View(nameof(ResumoDaCompra), await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
        }
    }
}
