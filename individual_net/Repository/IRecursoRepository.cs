using System.Linq;

namespace individual_net.Repository
{
    public interface IRecursoRepository
    {
        Recurso Create(Recurso recurso);
        Recurso Delete(long id);
        IQueryable<Recurso> Get();
        Recurso Get(long id);
        void Put(Recurso recurso);
    }
}