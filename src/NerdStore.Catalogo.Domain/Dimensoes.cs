using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        #region Public Constructors

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorQue(valor: altura,
                                         minimo: 1,
                                         mensagem: "O campo Altura não pode ser menor ou igual a 0");

            Validacoes.ValidarSeMenorQue(valor: largura,
                                         minimo: 1,
                                         mensagem: "O campo Largura não pode ser menor ou igual a 0");

            Validacoes.ValidarSeMenorQue(valor: profundidade,
                                         minimo: 1,
                                         mensagem: "O campo Profundidade não pode ser menor ou igual a 0");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        #endregion Public Constructors

        #region Public Properties

        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public string DescricaoFormatada() => $"LxAxP: {Largura} x {Altura} x {Profundidade}";

        public override string ToString() => DescricaoFormatada();

        #endregion Public Methods
    }
}
