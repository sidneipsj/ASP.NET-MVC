using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Filmoteca.Models;

namespace Filmoteca.Controllers
{
    public class FilmeController : ApiController
    {
        private FilmeDb db = new FilmeDb();

        // GET: api/Filme
        public IQueryable<Filme> GetFilmes()
        {
            return db.Filmes;
        }

        // GET: api/Filme/5
        [ResponseType(typeof(Filme))]
        public IHttpActionResult GetFilme(int id)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        // PUT: api/Filme/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilme(int id, Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filme.Id)
            {
                return BadRequest();
            }

            db.Entry(filme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Filme
        [ResponseType(typeof(Filme))]
        public IHttpActionResult PostFilme(Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filmes.Add(filme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = filme.Id }, filme);
        }

        // DELETE: api/Filme/5
        [ResponseType(typeof(Filme))]
        public IHttpActionResult DeleteFilme(int id)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return NotFound();
            }

            db.Filmes.Remove(filme);
            db.SaveChanges();

            return Ok(filme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmeExists(int id)
        {
            return db.Filmes.Count(e => e.Id == id) > 0;
        }
    }
}