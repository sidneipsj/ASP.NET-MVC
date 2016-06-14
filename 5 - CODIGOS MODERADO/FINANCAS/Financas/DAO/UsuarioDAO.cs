using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class UsuarioDAO
    {
        private FinancasContext context;

        public UsuarioDAO(FinancasContext context)
        {
            this.context = context;
        }

        public void Adiciona(Usuario usuario)
        {
            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();
        }

        public IList<Usuario> Lista()
        {
            return this.context.Usuarios.ToList();
        }
    }
}