using Microsoft.AspNetCore.Mvc;
using Portafolio_Curso.Interfaces;
using Portafolio_Curso.Models;
using Portafolio_Curso.Services;
using System.Diagnostics;

namespace Portafolio_Curso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository _project;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IProjectRepository project, IEmailService emailService)
        {
            _logger = logger;
            _project = project;
            _emailService = emailService;
        }

        public IActionResult Index()
        { 
            var proyectos = _project.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };

            return View(modelo);
        }

        public IActionResult Projects()
        {
            var projects = _project.ObtenerProyectos();
            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactDTO contactDTO)
        {
            await _emailService.Send(contactDTO);
            return RedirectToAction("Thanks");
        }

        public IActionResult Thanks()
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