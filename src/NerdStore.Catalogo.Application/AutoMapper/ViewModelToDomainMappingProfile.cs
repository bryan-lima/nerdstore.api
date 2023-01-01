using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(produtoViewModel => new Produto(produtoViewModel.Nome,
                                                                produtoViewModel.Descricao,
                                                                produtoViewModel.Ativo,
                                                                produtoViewModel.Valor,
                                                                produtoViewModel.CategoriaId,
                                                                produtoViewModel.DataCadastro,
                                                                produtoViewModel.Imagem,
                                                                new Dimensoes(produtoViewModel.Altura,
                                                                              produtoViewModel.Largura,
                                                                              produtoViewModel.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(categoriaViewModel => new Categoria(categoriaViewModel.Nome,
                                                                    categoriaViewModel.Codigo));
        }
    }
}
