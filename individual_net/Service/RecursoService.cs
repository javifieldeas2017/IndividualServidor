using individual_net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net.Service
{
    public class RecursoService : IRecursoService
    {
        private IRecursoRepository recursoRepository;
        public RecursoService(IRecursoRepository _recursoRepository)
        {
            this.recursoRepository = _recursoRepository;
        }

        public Recurso Get(long id)
        {
            return recursoRepository.Get(id);
        }

        public IQueryable<Recurso> Get()
        {
            return recursoRepository.Get();
        }

        public Recurso Create(Recurso recurso)
        {
            return recursoRepository.Create(recurso);
        }

        public void Put(Recurso recurso)
        {
            recursoRepository.Put(recurso);
        }

        public Recurso Delete(long id)
        {
            return recursoRepository.Delete(id);
        }
    }
}
