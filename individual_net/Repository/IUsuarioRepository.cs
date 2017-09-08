using System.Linq;

namespace individual_net.Repository
{
    public interface IUsuarioRepository
    {
        Usuario Create(Usuario usuario);
        Usuario Delete(long id);
        IQueryable<Usuario> Get();
        Usuario Get(long id);
        void Put(Usuario usuario);
    }
}