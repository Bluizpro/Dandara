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
    public class ClienteCadastroesController : Controller
    {
        private readonly DandaraContext _context;

        public ClienteCadastroesController(DandaraContext context)
        {
            _context = context;
        }

        // GET: ClienteCadastroes
        public async Task<IActionResult> Index()
        {
            var dandaraContext = _context.ClienteCadastro.Include(c => c.LoginCliente);
            return View(await dandaraContext.ToListAsync());
        }

        // GET: ClienteCadastroes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCadastro = await _context.ClienteCadastro
                .Include(c => c.LoginCliente)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (clienteCadastro == null)
            {
                return NotFound();
            }

            return View(clienteCadastro);
        }

        // GET: ClienteCadastroes/Create
        public IActionResult Create()
        {
            ViewData["Email"] = new SelectList(_context.Set<LoginCliente>(), "Email", "Email");
            return View();
        }

        // POST: ClienteCadastroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Nome,Sobrenome,CPF,Endereco,Bairro,Cidade,Telefone,Estado,Foto,CartaoCredito")] ClienteCadastro clienteCadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteCadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Email"] = new SelectList(_context.Set<LoginCliente>(), "Email", "Email", clienteCadastro.Email);
            return View(clienteCadastro);
        }

        // GET: ClienteCadastroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCadastro = await _context.ClienteCadastro.FindAsync(id);
            if (clienteCadastro == null)
            {
                return NotFound();
            }
            ViewData["Email"] = new SelectList(_context.Set<LoginCliente>(), "Email", "Email", clienteCadastro.Email);
            return View(clienteCadastro);
        }

        // POST: ClienteCadastroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Nome,Sobrenome,CPF,Endereco,Bairro,Cidade,Telefone,Estado,Foto,CartaoCredito")] ClienteCadastro clienteCadastro)
        {
            if (id != clienteCadastro.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteCadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteCadastroExists(clienteCadastro.Email))
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
            ViewData["Email"] = new SelectList(_context.Set<LoginCliente>(), "Email", "Email", clienteCadastro.Email);
            return View(clienteCadastro);
        }

        // GET: ClienteCadastroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCadastro = await _context.ClienteCadastro
                .Include(c => c.LoginCliente)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (clienteCadastro == null)
            {
                return NotFound();
            }

            return View(clienteCadastro);
        }

        // POST: ClienteCadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var clienteCadastro = await _context.ClienteCadastro.FindAsync(id);
            _context.ClienteCadastro.Remove(clienteCadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteCadastroExists(string id)
        {
            return _context.ClienteCadastro.Any(e => e.Email == id);
        }
    }
}
