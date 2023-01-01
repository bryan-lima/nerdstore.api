using NerdStore.Core.Messages;

namespace NerdStore.Core.DomainObjects
{
    public abstract class Entity
    {
        #region Private Fields

        private List<Event> _notificacoes;

        #endregion Private Fields

        #region Protected Constructors

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        #endregion Protected Constructors

        #region Public Properties

        public Guid Id { get; set; }
        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        #endregion Public Properties

        #region Public Methods

        public void AdicionarEvento(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }

        public void RemoverEvento(Event evento)
        {
            _notificacoes?.Remove(evento);
        }

        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }

        public override bool Equals(object objeto)
        {
            Entity _compareTo = objeto as Entity;

            if (ReferenceEquals(this, _compareTo)) return true;
            if (ReferenceEquals(null, _compareTo)) return false;

            return Id.Equals(_compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
