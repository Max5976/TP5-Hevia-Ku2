using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_Hevia_ku.Models;
using Newtonsoft.Json;
using TP5_Hevia_ku.Models;

namespace TP05_Hevia_ku.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    } 

    public IActionResult Index()
    {
        return View("Index");
    }

    public IActionResult Intro() 
    {
        return View("Presentacion/Intro");
    }

    public IActionResult Musica()
    {
        return View("Presentacion/Musica");
    }

    public IActionResult Logo()
    {
        return View("Presentacion/Logo");
    }

    public IActionResult IngresarNombre() 
    {
        return View("Presentacion/IngresarNombre");
    }

    public IActionResult Historia(string nuevoNombre) 
    {
        HttpContext.Session.SetString("nombre", nuevoNombre);
        ViewBag.nombre = nuevoNombre;
        return View("Presentacion/Historia");
    }

    public IActionResult CuartoI()
    {
        return View("SalaI/CuartoI");
    }

    public IActionResult PrimerCuarto() 
    {
        ViewBag.cuartoI = EstadoJuego.CuartoI;
        if (ViewBag.cuartoI.primeraPistaEncontrada == false) {
            ViewBag.segs = 100;
        }
        else {
            ViewBag.segs = 300;
        }
        return View("SalaI/PrimerCuarto");
    }

    public IActionResult NoDisponible()
    {
        return View("SalaI/NoDisponible");
    }

    public IActionResult Perdiste1()
    {
        return View("SalaI/Perdiste1");
    }

    public IActionResult Libro()
    {
        return View("SalaI/Libro");
    }

    public IActionResult Cofre()
    {
        return PartialView("SalaI/Cofre");
    }

    public IActionResult Carta()
    {
        EstadoJuego.CuartoI.primeraPistaEncontrada = true;
        return PartialView("SalaI/Carta");
    }
    
    public IActionResult NoDisponibleCofre()
    {
        return View("SalaI/NoDisponibleCofre");
    }

    public IActionResult Secreto()
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaI/Secreto");
    }

    public IActionResult Velas() 
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaI/Velas");
    }

    public IActionResult Vela() 
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaI/Vela");
    }

    public IActionResult HistoriaII()
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaI/HistoriaII");
    }
    
    public IActionResult Acertijos()
    {
        return View("SalaI/Acertijos");
    }

    public IActionResult VerificarCodigo(string codigo)
    {
        if (codigo.ToUpper() == "SATOIA")
        {
            return View("SalaI/HistoriaIII");
        }
        else
        {
            return View("SalaI/Error");
        }
    }

    public IActionResult HabitacionI()
    {
        ViewBag.segs = 300;
        return View("salaII/HabitacionI");
    }

    public IActionResult Computadora()
    {
        return View("salaII/Computadora");
    }

    [HttpPost]
    public IActionResult VerificarComputadora(string codigo)
    {
        if (codigo == "1234") // Cambia este código por el que desees
        {
            return RedirectToAction("HabitacionI");
        }
        return View("salaII/Computadora");
    }

    [HttpPost]
    public IActionResult ActualizarEstado([FromBody] EstadoUpdateModel model)
    {
        if (model.indices != null && model.estados != null)
        {
            for (int i = 0; i < model.indices.Length; i++)
            {
                if (i < model.estados.Length)
                {
                    EstadoJuego.CambiarEstadoArtefacto(model.indices[i], model.estados[i]);
                }
            }
        }
        return Ok();
    }
}