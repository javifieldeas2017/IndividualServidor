using individual_net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace individual_net.Repository
{
    public class RecursoRepository : IRecursoRepository
    {
        public Recurso Create(Recurso recurso)
        {
            return ApplicationDbContext.applicationDbContext.Recursos.Add(recurso);
        }

        public Recurso Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Recursos.Find(id);
        }

        public IQueryable<Recurso> Get()
        {
            IList<Recurso> lista = new List<Recurso>(ApplicationDbContext.applicationDbContext.Recursos);

            return lista.AsQueryable();
        }


        public void Put(Recurso recurso)
        {
            if (ApplicationDbContext.applicationDbContext.Recursos.Count(e => e.Id == recurso.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(recurso).State = EntityState.Modified;
        }

        public Recurso Delete(long id)
        {
            Recurso recurso = ApplicationDbContext.applicationDbContext.Recursos.Find(id);
            if (recurso == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Recursos.Remove(recurso);
            return recurso;
        }
    }
}