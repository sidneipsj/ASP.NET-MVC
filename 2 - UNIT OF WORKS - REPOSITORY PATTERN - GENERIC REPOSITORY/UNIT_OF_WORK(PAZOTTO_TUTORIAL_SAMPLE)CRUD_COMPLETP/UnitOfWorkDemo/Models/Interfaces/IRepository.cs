using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ObterTodos();
        T ObterPorId(int? id);
        void Inserir(T entity);
        void Excluir(T entity);
        void Excluir(int id);
        void Atualizar(T entity);
    }
}
