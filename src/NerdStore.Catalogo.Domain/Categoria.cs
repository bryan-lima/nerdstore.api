using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        #region Public Constructors

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        #endregion Public Constructors

        #region Protected Constructors

        protected Categoria()
        {

        }

        #endregion Protected Constructors

        #region Public Properties

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }

        #endregion Public Methods
    }
}
