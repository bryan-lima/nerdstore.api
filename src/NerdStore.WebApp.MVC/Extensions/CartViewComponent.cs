﻿using Microsoft.AspNetCore.Mvc;
using NerdStore.Vendas.Application.Queries;
using NerdStore.Vendas.Application.Queries.ViewModels;

namespace NerdStore.WebApp.MVC.Extensions
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IPedidoQueries _pedidoQueries;

        // TODO: Obter cliente logado
        protected Guid ClienteId = Guid.Parse("573B2556-8808-4A47-B036-4DC5C32B6C93");

        public CartViewComponent(IPedidoQueries pedidoQueries)
        {
            _pedidoQueries = pedidoQueries;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CarrinhoViewModel _carrinho = await _pedidoQueries.ObterCarrinhoCliente(ClienteId);
            int _itens = _carrinho?.Items.Count ?? 0;

            return View(_itens);
        }
    }
}
