using Dandara.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dandara.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult sobre()
        {
            return View();
        }

        public ViewResult Indexblog()
        {
            return View();
        }
        public ViewResult contato()
        {
            return View();
        }

        public ViewResult sobresite()
        {
            return View();
        }
        public ViewResult singupVendedor()
        {
            return View();
        }
        public ViewResult singupCliente()
        {
            return View();
        }
        public ViewResult singleproduct()
        {
            return View();
        }
        public ViewResult mariadosocorro()
        {
            return View();
        }
        public ViewResult manyproducts()
        {
            return View();
        }
        public ViewResult contatosite()
        {
            return View();
        }
        public ViewResult IndexSite()
        {
            return View();
        }
        public ViewResult cadastrovendedores()
        {
            return View();
        }
        public ViewResult cadastroprodutos()
        {
            return View();
        }
        public ViewResult cadastropessoal()
        {
            return View();
        }
        public ViewResult AreaCadastro()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
