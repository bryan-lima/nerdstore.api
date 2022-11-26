using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert

            DomainException _domainException = Assert.Throws<DomainException>(() => new Produto(nome: string.Empty,
                                                                                                descricao: "Descricao",
                                                                                                ativo: false,
                                                                                                valor: 100,
                                                                                                categoriaId: Guid.NewGuid(),
                                                                                                dataCadastro: DateTime.Now,
                                                                                                imagem: "Imagem",
                                                                                                dimensoes: new Dimensoes(altura: 1,
                                                                                                                         largura: 1,
                                                                                                                         profundidade: 1)));

            Assert.Equal(expected: "O campo Nome do produto n�o pode estar vazio",
                         actual: _domainException.Message);

            _domainException = Assert.Throws<DomainException>(() => new Produto(nome: "Nome",
                                                                                descricao: string.Empty,
                                                                                ativo: false,
                                                                                valor: 100,
                                                                                categoriaId: Guid.NewGuid(),
                                                                                dataCadastro: DateTime.Now,
                                                                                imagem: "Imagem",
                                                                                dimensoes: new Dimensoes(altura: 1,
                                                                                                         largura: 1,
                                                                                                         profundidade: 1)));

            Assert.Equal(expected: "O campo Descricao do produto n�o pode estar vazio",
                         actual: _domainException.Message);

            _domainException = Assert.Throws<DomainException>(() => new Produto("Nome",
                                                                                "Descricao",
                                                                                false,
                                                                                0,
                                                                                Guid.NewGuid(),
                                                                                DateTime.Now,
                                                                                "Imagem",
                                                                                dimensoes: new Dimensoes(altura: 1,
                                                                                                         largura: 1,
                                                                                                         profundidade: 1)));

            Assert.Equal(expected: "O campo Valor do produto n�o pode se menor igual a 0",
                         actual: _domainException.Message);

            _domainException = Assert.Throws<DomainException>(() => new Produto(nome: "Nome",
                                                                                descricao: "Descricao",
                                                                                ativo: false,
                                                                                valor: 100,
                                                                                categoriaId: Guid.Empty,
                                                                                dataCadastro: DateTime.Now,
                                                                                imagem: "Imagem",
                                                                                dimensoes: new Dimensoes(altura: 1,
                                                                                                         largura: 1,
                                                                                                         profundidade: 1)));

            Assert.Equal(expected: "O campo CategoriaId do produto n�o pode estar vazio",
                         actual: _domainException.Message);

            _domainException = Assert.Throws<DomainException>(() => new Produto(nome: "Nome",
                                                                                descricao: "Descricao",
                                                                                ativo: false,
                                                                                valor: 100,
                                                                                categoriaId: Guid.NewGuid(),
                                                                                dataCadastro: DateTime.Now,
                                                                                imagem: string.Empty,
                                                                                dimensoes: new Dimensoes(altura: 1,
                                                                                                         largura: 1,
                                                                                                         profundidade: 1)));

            Assert.Equal(expected: "O campo Imagem do produto n�o pode estar vazio",
                         actual: _domainException.Message);

            _domainException = Assert.Throws<DomainException>(() => new Produto(nome: "Nome",
                                                                                descricao: "Descricao",
                                                                                ativo: false,
                                                                                valor: 100,
                                                                                categoriaId: Guid.NewGuid(),
                                                                                dataCadastro: DateTime.Now,
                                                                                imagem: "Imagem",
                                                                                dimensoes: new Dimensoes(altura: 1,
                                                                                                         largura: 1,
                                                                                                         profundidade: 1)));

            Assert.Equal(expected: "O campo Altura n�o pode ser menor ou igual a 0",
                         actual: _domainException.Message);
        }
    }
}