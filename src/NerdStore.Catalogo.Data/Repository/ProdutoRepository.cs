using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        #region Private Fields

        private readonly CatalogoContext _context;

        #endregion Private Fields

        #region Public Constructors

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Properties

        public IUnitOfWork UnitOfWork => _context;

        #endregion Public Properties

        #region Public Methods

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _context.Produtos.AsNoTracking()
                                          .ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            //return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(produto => produto.Id == id);
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _context.Produtos.AsNoTracking()
                                          .Include(produto => produto.Categoria)
                                          .Where(produto => produto.Categoria.Codigo == codigo)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _context.Categorias.AsNoTracking()
                                            .ToListAsync();
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        #endregion Public Methods
    }
}
