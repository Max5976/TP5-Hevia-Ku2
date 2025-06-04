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

    public IActionResult IngresarNombre() 
    {
        return View("Presentacion/IngresarNombre");
    }
    public IActionResult Intro(string nuevoNombre)
    {
        HttpContext.Session.SetString("nombre", nuevoNombre);
        return View("Presentacion/Intro");
    }
    public IActionResult Historia() 
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("Presentacion/Historia");
    }
    public IActionResult PrimerCuarto() 
    {
        ViewBag.segs = 300;
        return View("SalaI/PrimerCuarto");
    }
    public IActionResult Perdiste() 
    {
        return View();
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
}
