using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWorkDemo.Models.Interfaces;

namespace UnitOfWorkDemo.Models.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        private readonly ApplicationDbContext _db;
        private IRepository<Post> _postRepository;
        private IRepository<Comentario> _comentarioRepository;

        public UnitOfWork()
        {
            _db = new ApplicationDbContext();
        }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }
        public IRepository<Post> PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository = new Repository<Post>(_db);
                }
                return _postRepository;
            }
        }

        public IRepository<Comentario> ComentarioRepository
        {
            get
            {
                if (_comentarioRepository == null)
                {
                    _comentarioRepository = new Repository<Comentario>(_db);
                }
                return _comentarioRepository;
            }
        }

        public void SalvarAlteracoes()
        {
            _db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}