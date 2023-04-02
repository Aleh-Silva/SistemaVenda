using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace SistemaVenda.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        protected ApplicationDbContext Repositorio;
        public HomeController(ApplicationDbContext repositorio)
        {
            Repositorio = repositorio;
        }

        public IActionResult Index()
        {
            Categoria objCategoria = Repositorio.Categoria.Where(x => x.Codigo == 1).FirstOrDefault();
            Repositorio.Attach(objCategoria);
            Repositorio.Remove(objCategoria);
            Repositorio.SaveChanges();
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