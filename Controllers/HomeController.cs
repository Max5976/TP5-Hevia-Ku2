using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_Hevia_ku.Models;
using Newtonsoft.Json;

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
        ViewBag.segs = 50;
        return View("SalaI/PrimerCuarto");
    }

    public IActionResult NoDisponible()
    {
        return View("NoDisponible");
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

    public IActionResult HistoriaII()
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaI/HistoriaII");
    }

    public IActionResult VerificarCodigo(string codigo) 
    {
        if (codigo == "SATOIA") {
            return View("SalaI/HistoriaIII");
        }
        else {
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
}
