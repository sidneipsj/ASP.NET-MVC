using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnitOfWorkDemo.Models.Interfaces;

namespace UnitOfWorkDemo.Models.Repositorios
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<T> ObterTodos()
        {
            return _db.Set<T>();
        }

        public T ObterPorId(int? id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Inserir(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Excluir(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void Excluir(int id)
        {
            var entity = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(entity);
        }

        public void Atualizar(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}