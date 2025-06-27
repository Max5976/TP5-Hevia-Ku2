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

        if (ViewBag.cuartoI.primeraPistaEncontrada == false)
        {
            ViewBag.segs = 100;
        }
        else
        {
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
        return View("SalaI/Cofre");
    }

    public IActionResult Carta()
    {
        EstadoJuego.CuartoI.primeraPistaEncontrada = true;
        return View("SalaI/Carta");
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

    [HttpPost]
    public IActionResult ActualizarEstado([FromBody] EstadoUpdateModel model)
    {
        for (int i = 0; i < model.indices.Length; i++)
        {
            EstadoJuego.CambiarEstadoArtefacto(model.indices[i], model.estados[i]);
        }
        return Ok();
    }

    public IActionResult Acertijos()
    {
        return View("SalaI/Acertijos");
    }

    public IActionResult VerificarCodigo(string codigo)
    {
        if (codigo.ToUpper() == "SATOIA")
        {
            ViewBag.nombre = HttpContext.Session.GetString("nombre");
            return View("SalaI/HistoriaIII");
        }
        else
        {
            return View("SalaI/Error");
        }
    }

    public IActionResult CuartoII()
    {
        return View("SalaII/CuartoII");
    }

    public IActionResult HabitacionII()
    {
        ViewBag.segs = 300;
        return View("SalaII/HabitacionII");
    }

    public IActionResult Perdiste2()
    {
        return View("SalaII/Perdiste2");
    }

    public IActionResult Computadora()
    {
        return View("SalaII/Computadora");
    }

    [HttpPost]
    public IActionResult VerificarComputadora(string codigo)
    {
        if (codigo == "2P0l1sgKa") 
        {
            return RedirectToAction("ComputadoraInicio");
        }

        ViewBag.Error = "Contraseña incorrecta";
        return View("salaII/Computadora");
    }

    public IActionResult ComputadoraInicio()
    {
        return View("SalaII/ComputadoraInicio");
    }

    public IActionResult HistoriaIV() {
        return View("SalaII/HistoriaIV");
    }

    public IActionResult CuartoIII()
    {
        return View("SalaIII/CuartoIII");
    }
    public IActionResult TercerCuarto()
    {
        ViewBag.cuartoIII = EstadoJuego.CuartoIII;
        if (ViewBag.cuartoIII.primeraPistaEncontrada == false)
        {
            ViewBag.segs = 300;
        }
        else
        {
            ViewBag.segs = 100;
        }
        return View("SalaIII/TercerCuarto");
    }
    public IActionResult Perdiste3() {
        return View("SalaIII/Perdiste3");
    }
    public IActionResult NoDisponible3() {
        return View("SalaIII/NoDisponible3");
    }
}