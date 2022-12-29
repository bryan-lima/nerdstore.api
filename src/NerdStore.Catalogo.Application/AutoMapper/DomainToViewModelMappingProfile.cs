using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(produtoViewModel => produtoViewModel.Largura,
                           config => config.MapFrom(produto => produto.Dimensoes.Largura))
                .ForMember(produtoViewModel => produtoViewModel.Altura,
                           config => config.MapFrom(produto => produto.Dimensoes.Altura))
                .ForMember(produtoViewModel => produtoViewModel.Profundidade,
                           config => config.MapFrom(produto => produto.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
