using CaptaAvaliacao.Models;
using CaptaAvaliacao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaptaAvaliacao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(IndexModel indexModel = null)
        {
            if(indexModel == null)
            {
                indexModel = new IndexModel();
            }
            return View(indexModel);
        }
        public IActionResult ExcluirCliente(string id)
        {
            IndexModel indexModel = new IndexModel();
            Cliente cliente = new Cliente();
            cliente.CPF = id;
            indexModel.msgRetorno = cliente.DelCliente();
            return RedirectToAction("Index", indexModel);
        }
        public IActionResult CadastrarCliente(string id = null)
        {
            Cliente cliente = new Cliente();
            cliente.CPF = id;
            cliente = cliente.GetCliente();
            CadastroCliente cadastroCliente = new CadastroCliente();
            cadastroCliente.cliente = cliente;
            return View(cadastroCliente);
        }
        public IActionResult SalvarCliente(Cliente cliente)
        {
            IndexModel indexModel = new IndexModel();
            indexModel.msgRetorno = cliente.SetCliente();
            
            return RedirectToAction("Index", indexModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}