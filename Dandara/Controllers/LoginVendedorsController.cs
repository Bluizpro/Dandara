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
    public class LoginVendedorsController : Controller
    {
        private readonly DandaraContext _context;

        public LoginVendedorsController(DandaraContext context)
        {
            _context = context;
        }

        // GET: LoginVendedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginVendedor.ToListAsync());
        }

        // GET: LoginVendedors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginVendedor = await _context.LoginVendedor
                .FirstOrDefaultAsync(m => m.Email == id);
            if (loginVendedor == null)
            {
                return NotFound();
            }

            return View(loginVendedor);
        }

        // GET: LoginVendedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginVendedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Senha")] LoginVendedor loginVendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginVendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginVendedor);
        }

        // GET: LoginVendedors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginVendedor = await _context.LoginVendedor.FindAsync(id);
            if (loginVendedor == null)
            {
                return NotFound();
            }
            return View(loginVendedor);
        }

        // POST: LoginVendedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Senha")] LoginVendedor loginVendedor)
        {
            if (id != loginVendedor.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginVendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginVendedorExists(loginVendedor.Email))
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
            return View(loginVendedor);
        }

        // GET: LoginVendedors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginVendedor = await _context.LoginVendedor
                .FirstOrDefaultAsync(m => m.Email == id);
            if (loginVendedor == null)
            {
                return NotFound();
            }

            return View(loginVendedor);
        }

        // POST: LoginVendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loginVendedor = await _context.LoginVendedor.FindAsync(id);
            _context.LoginVendedor.Remove(loginVendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginVendedorExists(string id)
        {
            return _context.LoginVendedor.Any(e => e.Email == id);
        }
    }
}
