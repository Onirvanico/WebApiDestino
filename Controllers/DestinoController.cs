using AppWebCSharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebCSharp.Controllers
{
    public class DestinoController : Controller
    {
        private readonly DestinoDBContext _context;

        public DestinoController(DestinoDBContext context)
        {
            _context = context;
        }
        // GET: DestinoController
        public ActionResult Index()
        {
            var destinos = _context.Destinos.ToList();
            return View(destinos);
        }

        // GET: DestinoController/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1) return NotFound();
            var destino = _context.Destinos.SingleOrDefault(model => model.ID == id);
            if (destino == null) return NotFound();
            return View(destino);
        }

        // GET: DestinoController/Create
        public ActionResult Save()
        {
            return View();
        }

        // POST: DestinoController/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Destino destino)
        {
            try
            {
                _context.Add(destino);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DestinoController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 1) return NotFound();
            var destino = _context.Destinos.SingleOrDefault(model => model.ID == id);
            if (destino == null) NotFound();

            return View(destino);
        }

        // POST: DestinoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Destino destino)
        {
            if (id != destino.ID) return BadRequest();
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Update(destino);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }

            return View(destino);
        }

        // GET: DestinoController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1) return NotFound();
            var destino = _context.Destinos.SingleOrDefault(model => model.ID == id);
            if (destino == null) NotFound();

            return View(destino);
        }

        // POST: DestinoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRest(int id)
        {
            try
            {
                var destino = _context.Destinos.SingleOrDefault(model => model.ID == id);
                if(destino != null)
                {
                    _context.Remove(destino);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }

            return View();
        }
    }
}
