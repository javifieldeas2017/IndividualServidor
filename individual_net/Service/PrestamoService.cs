using individual_net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net.Service
{
    public class PrestamoService : IPrestamoService
    {
        private IPrestamoRepository prestamoRepository;
        public PrestamoService(IPrestamoRepository _prestamoRepository)
        {
            this.prestamoRepository = _prestamoRepository;
        }

        public Prestamo Get(long id)
        {
            return prestamoRepository.Get(id);
        }

        public IQueryable<Prestamo> Get()
        {
            return prestamoRepository.Get();
        }

        public Prestamo Create(Prestamo prestamo)
        {
            return prestamoRepository.Create(prestamo);
        }

        public void Put(Prestamo prestamo)
        {
            prestamoRepository.Put(prestamo);
        }

        public Prestamo Delete(long id)
        {
            return prestamoRepository.Delete(id);
        }
    }
}
