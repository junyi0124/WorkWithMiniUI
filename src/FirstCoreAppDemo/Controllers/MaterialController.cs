using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstCoreAppDemo.Data;
using FirstCoreAppDemo.Models;

namespace FirstCoreAppDemo.Controllers
{
    public class MaterialController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Material
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materials.ToListAsync());
        }

        // GET: Material/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialEntity = await _context.Materials.SingleOrDefaultAsync(m => m.Id == id);
            if (materialEntity == null)
            {
                return NotFound();
            }

            return View(materialEntity);
        }

        // GET: Material/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,FullCode,FullName,Name,PId,Unit")] MaterialEntity materialEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(materialEntity);
        }

        // GET: Material/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialEntity = await _context.Materials.SingleOrDefaultAsync(m => m.Id == id);
            if (materialEntity == null)
            {
                return NotFound();
            }
            return View(materialEntity);
        }

        // POST: Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,FullCode,FullName,Name,PId,Unit")] MaterialEntity materialEntity)
        {
            if (id != materialEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialEntityExists(materialEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(materialEntity);
        }

        // GET: Material/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialEntity = await _context.Materials.SingleOrDefaultAsync(m => m.Id == id);
            if (materialEntity == null)
            {
                return NotFound();
            }

            return View(materialEntity);
        }

        // POST: Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialEntity = await _context.Materials.SingleOrDefaultAsync(m => m.Id == id);
            _context.Materials.Remove(materialEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MaterialEntityExists(int id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
    }
}
