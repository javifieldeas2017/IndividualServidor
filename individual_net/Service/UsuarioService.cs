using individual_net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net.Service
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository _usuarioRepository)
        {
            this.usuarioRepository = _usuarioRepository;
        }

        public Usuario Get(long id)
        {
            return usuarioRepository.Get(id);
        }

        public IQueryable<Usuario> Get()
        {
            return usuarioRepository.Get();
        }

        public Usuario Create(Usuario usuario)
        {
            return usuarioRepository.Create(usuario);
        }

        public void Put(Usuario usuario)
        {
            usuarioRepository.Put(usuario);
        }

        public Usuario Delete(long id)
        {
            return usuarioRepository.Delete(id);
        }
    }
}
