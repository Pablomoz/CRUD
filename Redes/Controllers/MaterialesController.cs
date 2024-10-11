using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Redes.Models;
using System.Collections.Generic;

namespace Redes.Controllers
{
    public class MaterialesController : Controller
    {
        private readonly BodegaContext _context;

        public MaterialesController(BodegaContext context)
        {

            _context = context;
        }



        public async Task<IActionResult> Listar()
        {
            var redes = await _context.Redes.ToListAsync();
            return View(redes);

        }

        // GET: Materiales/Create
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Materiales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

     
        //public async Task<IActionResult> Crear([Bind("Id,Nombre,Cantidad")] Redes.Models.Redes redes)
        public async Task<IActionResult> Crear(Models.Redes redes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(redes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(redes);
        }



        // GET: Materiales/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var redes = await _context.Redes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (redes == null)
            {
               return NotFound();
            }

           return View(redes);
        }

        // POST: Materiales/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var redes = await _context.Redes.FindAsync(id);
            _context.Redes.Remove(redes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }




        // GET: Materiales/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redes = await _context.Redes.FindAsync(id);
            if (redes == null)
            {
                return NotFound();
            }
            return View(redes);
 }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Redes.Models.Redes redes)
        {
            if (id != redes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(redes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }

            return View(redes);



        }
        }
    }

