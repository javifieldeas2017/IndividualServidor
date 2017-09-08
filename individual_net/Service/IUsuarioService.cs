using System.Linq;

namespace individual_net.Service
{
    public interface IUsuarioService
    {
        Usuario Create(Usuario recurso);
        Usuario Delete(long id);
        IQueryable<Usuario> Get();
        Usuario Get(long id);
        void Put(Usuario recurso);
    }
}