using individual_net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace individual_net.Repository
{
    public class PrestamoRepository : IPrestamoRepository
    {
        public Prestamo Create(Prestamo prestamo)
        {
            return ApplicationDbContext.applicationDbContext.Prestamos.Add(prestamo);
        }

        public Prestamo Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Prestamos.Find(id);
        }

        public IQueryable<Prestamo> Get()
        {
            IList<Prestamo> lista = new List<Prestamo>(ApplicationDbContext.applicationDbContext.Prestamos);

            return lista.AsQueryable();
        }


        public void Put(Prestamo prestamo)
        {
            if (ApplicationDbContext.applicationDbContext.Prestamos.Count(e => e.Id == prestamo.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(prestamo).State = EntityState.Modified;
        }

        public Prestamo Delete(long id)
        {
            Prestamo prestamo = ApplicationDbContext.applicationDbContext.Prestamos.Find(id);
            if (prestamo == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Prestamos.Remove(prestamo);
            return prestamo;
        }
    }
}