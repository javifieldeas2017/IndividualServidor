using System.Linq;

namespace individual_net.Repository
{
    public interface IPrestamoRepository
    {
        Prestamo Create(Prestamo prestamo);
        Prestamo Delete(long id);
        IQueryable<Prestamo> Get();
        Prestamo Get(long id);
        void Put(Prestamo prestamo);
    }
}