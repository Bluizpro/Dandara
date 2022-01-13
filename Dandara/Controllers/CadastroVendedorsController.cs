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
    public class CadastroVendedorsController : Controller
    {
        private readonly DandaraContext _context;

        public CadastroVendedorsController(DandaraContext context)
        {
            _context = context;
        }

        // GET: CadastroVendedors
        public async Task<IActionResult> Index()
        {
            var dandaraContext = _context.CadastroVendedor.Include(c => c.LoginVendedor);
            return View(await dandaraContext.ToListAsync());
        }

        // GET: CadastroVendedors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVendedor = await _context.CadastroVendedor
                .Include(c => c.LoginVendedor)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (cadastroVendedor == null)
            {
                return NotFound();
            }

            return View(cadastroVendedor);
        }

        // GET: CadastroVendedors/Create
        public IActionResult Create()
        {
            ViewData["Email"] = new SelectList(_context.Set<LoginVendedor>(), "Email", "Email");
            return View();
        }

        // POST: CadastroVendedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Nome,Sobrenome,CPF,mei,Cnpj,RG,Endereco,Bairro,Cidade,Telefone,Estado,Foto,CartaoCredito,LinkVideo,DescriçãoAtividade")] CadastroVendedor cadastroVendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroVendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Email"] = new SelectList(_context.Set<LoginVendedor>(), "Email", "Email", cadastroVendedor.Email);
            return View(cadastroVendedor);
        }

        // GET: CadastroVendedors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVendedor = await _context.CadastroVendedor.FindAsync(id);
            if (cadastroVendedor == null)
            {
                return NotFound();
            }
            ViewData["Email"] = new SelectList(_context.Set<LoginVendedor>(), "Email", "Email", cadastroVendedor.Email);
            return View(cadastroVendedor);
        }

        // POST: CadastroVendedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Nome,Sobrenome,CPF,mei,Cnpj,RG,Endereco,Bairro,Cidade,Telefone,Estado,Foto,CartaoCredito,LinkVideo,DescriçãoAtividade")] CadastroVendedor cadastroVendedor)
        {
            if (id != cadastroVendedor.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroVendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroVendedorExists(cadastroVendedor.Email))
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
            ViewData["Email"] = new SelectList(_context.Set<LoginVendedor>(), "Email", "Email", cadastroVendedor.Email);
            return View(cadastroVendedor);
        }

        // GET: CadastroVendedors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVendedor = await _context.CadastroVendedor
                .Include(c => c.LoginVendedor)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (cadastroVendedor == null)
            {
                return NotFound();
            }

            return View(cadastroVendedor);
        }

        // POST: CadastroVendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cadastroVendedor = await _context.CadastroVendedor.FindAsync(id);
            _context.CadastroVendedor.Remove(cadastroVendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroVendedorExists(string id)
        {
            return _context.CadastroVendedor.Any(e => e.Email == id);
        }
    }
}
