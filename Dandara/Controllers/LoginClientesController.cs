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
    public class LoginClientesController : Controller
    {
        private readonly DandaraContext _context;

        public LoginClientesController(DandaraContext context)
        {
            _context = context;
        }

        // GET: LoginClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginCliente.ToListAsync());
        }

        // GET: LoginClientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginCliente = await _context.LoginCliente
                .FirstOrDefaultAsync(m => m.Email == id);
            if (loginCliente == null)
            {
                return NotFound();
            }

            return View(loginCliente);
        }

        // GET: LoginClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Senha")] LoginCliente loginCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginCliente);
        }

        // GET: LoginClientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginCliente = await _context.LoginCliente.FindAsync(id);
            if (loginCliente == null)
            {
                return NotFound();
            }
            return View(loginCliente);
        }

        // POST: LoginClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Senha")] LoginCliente loginCliente)
        {
            if (id != loginCliente.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginClienteExists(loginCliente.Email))
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
            return View(loginCliente);
        }

        // GET: LoginClientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginCliente = await _context.LoginCliente
                .FirstOrDefaultAsync(m => m.Email == id);
            if (loginCliente == null)
            {
                return NotFound();
            }

            return View(loginCliente);
        }

        // POST: LoginClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loginCliente = await _context.LoginCliente.FindAsync(id);
            _context.LoginCliente.Remove(loginCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginClienteExists(string id)
        {
            return _context.LoginCliente.Any(e => e.Email == id);
        }
    }
}
