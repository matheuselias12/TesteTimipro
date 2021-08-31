using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimproTeste.Entidade;

namespace TimproTeste.Controllers
{
    public class ImovelsController : Controller
    {
        private TesteTimipro db = new TesteTimipro();

        // GET: Imovels
        public ActionResult Index()
        {
            var imovel = db.Imovel.AsQueryable().Where(i => (int)i.StatusImovel == 1);
            return View(imovel.ToList());
        }

        // GET: Imovels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel imovel = db.Imovel.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            return View(imovel);
        }

        // GET: Imovels/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => (int)c.Status == 1), "ClienteId", "Nome");
            return View();
        }

        // POST: Imovels/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImovelId,Valor,Descricao,StatusImovel,ClienteId")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                imovel.ImovelId = Guid.NewGuid();
                db.Imovel.Add(imovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", imovel.ClienteId);
            return View(imovel);
        }

        // GET: Imovels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel imovel = db.Imovel.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => (int)c.Status == 1), "ClienteId", "Nome", imovel.ClienteId);
            return View(imovel);
        }

        // POST: Imovels/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImovelId,Valor,Descricao,StatusImovel,ClienteId")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", imovel.ClienteId);
            return View(imovel);
        }

        // GET: Imovels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel imovel = db.Imovel.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            return View(imovel);
        }

        // POST: Imovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var cliente = db.Clientes.Where(c => c.ImovelId == id).ToList();

            if (cliente.Count > 0)
            {
                TempData["Erro"] = "Não pode ser excluído, pois contem cliente vinculado a este imovel";
                return RedirectToAction("Index");
            }
            Imovel imovel = db.Imovel.Find(id);
            db.Imovel.Remove(imovel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
