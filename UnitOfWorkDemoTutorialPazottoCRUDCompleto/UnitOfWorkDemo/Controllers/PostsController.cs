using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UnitOfWorkDemo.Models;
using UnitOfWorkDemo.Models.Interfaces;
using UnitOfWorkDemo.Models.Repositorios;

namespace UnitOfWorkDemo.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Post> _repository;

        public PostsController()
        {
            _unitOfWork = new UnitOfWork();
            _repository = _unitOfWork.PostRepository;
        }

        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.PostRepository;
        }

        public ActionResult Index()
        {
            return View(_repository.ObterTodos().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = _repository.ObterPorId(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "PostId,Titulo,Conteudo,DataCriacao")] Post post)
        {
            if (ModelState.IsValid)
            {
                _repository.Inserir(post);
                _unitOfWork.SalvarAlteracoes();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _repository.ObterPorId(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
                [Bind(Include = "PostId,Titulo,Conteudo,DataCriacao")] Post post)
        {
            if (ModelState.IsValid)
            {
                _repository.Atualizar(post);
                _unitOfWork.SalvarAlteracoes();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _repository.ObterPorId(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Excluir(id);
            _unitOfWork.SalvarAlteracoes();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
