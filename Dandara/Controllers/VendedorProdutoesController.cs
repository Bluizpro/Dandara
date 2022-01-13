using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dandara.Data;
using Dandara.Models;

namespace Dandara.Controllers
{
    public class VendedorProdutoesController : Controller
    {
        private readonly DandaraContext _context;

        public VendedorProdutoesController(DandaraContext context)
        {
            _context = context;
        }

        // GET: VendedorProdutoes
        public async Task<IActionResult> Index()
        {
            var dandaraContext = _context.VendedorProduto.Include(v => v.Produto);
            return View(await dandaraContext.ToListAsync());
        }

        // GET: VendedorProdutoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedorProduto = await _context.VendedorProduto
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (vendedorProduto == null)
            {
                return NotFound();
            }

            return View(vendedorProduto);
        }

        // GET: VendedorProdutoes/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "id", "id");
            return View();
        }

        // POST: VendedorProdutoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,VendedorId,ProdutoId")] VendedorProduto vendedorProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedorProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "id", "id", vendedorProduto.ProdutoId);
            return View(vendedorProduto);
        }

        // GET: VendedorProdutoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedorProduto = await _context.VendedorProduto.FindAsync(id);
            if (vendedorProduto == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "id", "id", vendedorProduto.ProdutoId);
            return View(vendedorProduto);
        }

        // POST: VendedorProdutoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,VendedorId,ProdutoId")] VendedorProduto vendedorProduto)
        {
            if (id != vendedorProduto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedorProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorProdutoExists(vendedorProduto.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "id", "id", vendedorProduto.ProdutoId);
            return View(vendedorProduto);
        }

        // GET: VendedorProdutoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedorProduto = await _context.VendedorProduto
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (vendedorProduto == null)
            {
                return NotFound();
            }

            return View(vendedorProduto);
        }

        // POST: VendedorProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedorProduto = await _context.VendedorProduto.FindAsync(id);
            _context.VendedorProduto.Remove(vendedorProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorProdutoExists(int id)
        {
            return _context.VendedorProduto.Any(e => e.id == id);
        }
    }
}
