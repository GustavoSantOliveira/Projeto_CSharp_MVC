using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Contatos.Models;

namespace Contatos.Controllers
{
    public class ContatosController : Controller
    {
        ContatoDbContext db;
        public ContatosController()
        {
            db = new ContatoDbContext();
        }

        /// <summary>
        /// Consultar os contatos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var contatos = db.Contatos.ToList();
            return View(contatos);
        }

        public ActionResult Create()
        {
            var model = new ContatoViewModel();
            return View(model);
        }

        /// <summary>
        /// Incluir contato
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contato = new Contato();
                contato.Nome = model.Nome;
                contato.Email = model.Email;
                contato.Telefone = model.Telefone;

                db.Contatos.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        /// <summary>
        /// Editar contato
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Telefone")] Contato model)
        {
            if (ModelState.IsValid)
            {
                var contato = db.Contatos.Find(model.Id);
                if (contato == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                contato.Nome = model.Nome;
                contato.Email = model.Email;
                contato.Telefone = model.Telefone;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }
        
        /// <summary>
        /// Excluir um contato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contato contato = db.Contatos.Find(id);
            db.Contatos.Remove(contato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}