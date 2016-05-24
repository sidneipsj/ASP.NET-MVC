using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lojaComEntity.Entidades;

namespace lojaComEntity
{
    public class UsuarioDao
    {
        private EntidadesContext contexto;
        public UsuarioDao(EntidadesContext ctx)
        {
            contexto = ctx;
        }

        public void Salva(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public Usuario BuscaPorId(int id)
        {
            return contexto.Usuarios.FirstOrDefault(u => u.ID == id);
        }

        public void Remove(Usuario u)
        {
            contexto.Usuarios.Remove(u);
            contexto.SaveChanges();
        }

        public void Atualiza()
        {
            contexto.SaveChanges();
        }
    }
}
