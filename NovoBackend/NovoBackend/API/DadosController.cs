using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NovoBackend.Models;
using NovoBackend.Models.Contexto;

namespace NovoBackend.API
{
    public class DadosController : ApiController
    {
        private MeuNovoContexto db = new MeuNovoContexto();

        // GET: api/Dados
        public IQueryable<Dados> GetDados()
        {
            return db.Dados;
        }

        // GET: api/Dados/5
        [ResponseType(typeof(Dados))]
        public IHttpActionResult GetDados(int id)
        {
            Dados dados = db.Dados.Find(id);
            if (dados == null)
            {
                return NotFound();
            }

            return Ok(dados);
        }

        // PUT: api/Dados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDados(int id, Dados dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dados.DadosID)
            {
                return BadRequest();
            }

            db.Entry(dados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadosExists(id))
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

        // POST: api/Dados
        [ResponseType(typeof(Dados))]
        public IHttpActionResult PostDados(Dados dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dados.Add(dados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dados.DadosID }, dados);
        }

        // DELETE: api/Dados/5
        [ResponseType(typeof(Dados))]
        public IHttpActionResult DeleteDados(int id)
        {
            Dados dados = db.Dados.Find(id);
            if (dados == null)
            {
                return NotFound();
            }

            db.Dados.Remove(dados);
            db.SaveChanges();

            return Ok(dados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DadosExists(int id)
        {
            return db.Dados.Count(e => e.DadosID == id) > 0;
        }
    }
}