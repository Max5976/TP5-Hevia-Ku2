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
        EstadoJuego.CuartoI.primeraPistaEncontrada = false;
        EstadoJuego.CuartoI.segundaPistaEncontrada = false;
        EstadoJuego.CuartoI.cosas[0].estadoDeMaterial = true;
        EstadoJuego.CuartoI.cosas[2].estadoDeMaterial = false;
        EstadoJuego.CuartoI.cosas[6].estadoDeMaterial = false;
        return View("SalaI/CuartoI");
    }

    public IActionResult PrimerCuarto()
    {
        ViewBag.cuartoI = EstadoJuego.CuartoI;

        if (ViewBag.cuartoI.primeraPistaEncontrada == false)
        {
            ViewBag.segs = 300;
        }
        else
        {
            ViewBag.segs = 300;
        }
        return View("SalaI/PrimerCuarto");
    }

    public IActionResult NoDisponible()
    {
        ViewBag.sala = "SalaI";
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/NoDisponible");
    }

    public IActionResult Perdiste1()
    {
        return View("SalaI/Perdiste1");
    }

    public IActionResult Libro()
    {
        ViewBag.sala = "SalaI";
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/Libro");
    }

    public IActionResult Cofre()
    {
        ViewBag.sala = "SalaI";
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/Cofre");
    }

    public IActionResult Carta()
    {
        ViewBag.sala = "SalaI";
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/Carta");
    }

    public IActionResult NoDisponibleCofre()
    {
        ViewBag.sala = "SalaI";
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/NoDisponibleCofre");
    }

    public IActionResult Secreto()
    {
        ViewBag.sala = "SalaI";
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/Secreto");
    }

    public IActionResult Velas()
    {
        ViewBag.sala = "SalaI";
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/Velas");
    }

    public IActionResult Vela()
    {
        ViewBag.sala = "SalaI";
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/Vela");
    }

    public IActionResult HistoriaII()
    {
        ViewBag.sala = "SalaI";
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        EstadoJuego.CuartoI.primeraPistaEncontrada = true;
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
        ViewBag.sala = "SalaI";
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
        return View("SalaI/Acertijos");
    }

    public IActionResult VerificarCodigo(string codigo)
    {
        ViewBag.segs = EstadoJuego.CuartoI.primeraPistaEncontrada == false ? 300 : 300;
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
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaIII/HistoriaIV");
    }

    public IActionResult CuartoIII()
    {
        EstadoJuego.CuartoIII.primeraPistaEncontrada = false;
        EstadoJuego.CuartoIII.segundaPistaEncontrada = false;
        EstadoJuego.CuartoIII.cosas[1].estadoDeMaterial = false;
        EstadoJuego.CuartoIII.cosas[2].estadoDeMaterial = false;
        EstadoJuego.CuartoIII.cosas[3].estadoDeMaterial = false;
        EstadoJuego.CuartoIII.cosas[4].estadoDeMaterial = false;
        EstadoJuego.CuartoIII.cosas[6].estadoDeMaterial = true;
        EstadoJuego.CuartoIII.cosas[7].estadoDeMaterial = false;
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
            ViewBag.segs = 200;
        }
        return View("SalaIII/TercerCuarto");
    }
    public IActionResult Perdiste3() {
        return View("SalaIII/Perdiste3");
    }
    public IActionResult NoDisponible3() {
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/NoDisponible3");
    }
    public IActionResult VelaColgada() {
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/VelaColgada");
    }
    public IActionResult Cajon() {
        EstadoJuego.CuartoIII.cosas[1].estadoDeMaterial = true;
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/Cajon");
    }
    public IActionResult Cajon2() {
        EstadoJuego.CuartoIII.cosas[2].estadoDeMaterial = true;
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/Cajon2");
    }
    public IActionResult Vasija() {
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/Vasija");
    }
    public IActionResult Lista() {
        EstadoJuego.CuartoIII.cosas[7].estadoDeMaterial = true;
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/Lista");
    }
    public IActionResult HistoriaV() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/HistoriaV");
    }
    public IActionResult Cocinar() {
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        ViewBag.sala = "SalaIII";
        EstadoJuego.CuartoIII.primeraPistaEncontrada = true;
        EstadoJuego.CuartoIII.cosas[3].estadoDeMaterial = true;
        EstadoJuego.CuartoIII.cosas[6].estadoDeMaterial = false;
        EstadoJuego.CuartoIII.cosas[7].estadoDeMaterial = false;
        return View("SalaIII/Cocinar");
    }
    public IActionResult HistoriaVI() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        EstadoJuego.CuartoIII.segundaPistaEncontrada = true;
        ViewBag.sala = "SalaIII";
        return View("SalaIII/HistoriaVI");
    }
    public IActionResult Papel() {
        ViewBag.sala = "SalaIII";
        EstadoJuego.CuartoIII.cosas[4].estadoDeMaterial = true;
        return View("SalaIII/Papel");
    }
    public IActionResult Oscuridad() {
        ViewBag.sala = "SalaIII";
        return View("SalaIII/Oscuridad");
    }
    public IActionResult Error() {
        ViewBag.sala = "SalaIII";
        return View("SalaIII/Error");
    }
    public IActionResult e38dah12dska() {
        ViewBag.sala = "SalaIII";
        return View("SalaIII/e38dah12dska"); 
    }
    public IActionResult VerificarCodigo2(string codigo)
    {
        ViewBag.segs = EstadoJuego.CuartoIII.primeraPistaEncontrada == false ? 300 : 200;
        if (codigo == "Lsca23")
        {
            ViewBag.nombre = HttpContext.Session.GetString("nombre");
            return View("SalaIII/HistoriaVII");
        }
        else
        {
            return View("SalaIII/Error3");
        }
    }
    public IActionResult HistoriaVII() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaIII/HistoriaVII"); 
    }
    public IActionResult CuartoIV() {
        return View("SalaIV/CuartoIV"); 
    }
    public IActionResult Infiltracion() {
        return View("SalaIV/Infiltracion"); 
    }
    public IActionResult Perdiste4() {
        return View("SalaIV/Perdiste4");
    }
    public IActionResult HistoriaVIII() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaV/HistoriaVIII");
    }
    public IActionResult CuartoV() {
        EstadoJuego.CuartoV.primeraPistaEncontrada = false;
        EstadoJuego.CuartoV.segundaPistaEncontrada = false;
        EstadoJuego.CuartoV.cosas[1].estadoDeMaterial = true;
        EstadoJuego.CuartoV.cosas[6].estadoDeMaterial = false;
        EstadoJuego.CuartoV.cosas[7].estadoDeMaterial = false;
        EstadoJuego.CuartoV.cosas[8].estadoDeMaterial = false;
        EstadoJuego.CuartoV.cosas[9].estadoDeMaterial = false;
        EstadoJuego.CuartoV.cosas[10].estadoDeMaterial = false;
        return View("SalaV/CuartoV");
    }
    public IActionResult QuintoCuarto() {
        ViewBag.cuartoV = EstadoJuego.CuartoV;
        if (ViewBag.cuartoV.primeraPistaEncontrada == false)
        {
            ViewBag.segs = 100;
        }
        else
        {
            ViewBag.segs = 300;
        }
        return View("SalaV/QuintoCuarto"); 
    }
    public IActionResult Perdiste5() {
        return View("SalaV/Perdiste5");
    }
    public IActionResult NoDisponible5() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/NoDisponible5");
    }
    public IActionResult Nota() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        EstadoJuego.CuartoV.primeraPistaEncontrada = true;
        EstadoJuego.CuartoV.cosas[1].estadoDeMaterial = false;
        EstadoJuego.CuartoV.cosas[6].estadoDeMaterial = true;
        EstadoJuego.CuartoV.cosas[7].estadoDeMaterial = true;
        EstadoJuego.CuartoV.cosas[8].estadoDeMaterial = true;
        EstadoJuego.CuartoV.cosas[9].estadoDeMaterial = true;
        EstadoJuego.CuartoV.cosas[10].estadoDeMaterial = true;
        ViewBag.sala = "SalaV";
        return View("SalaV/Nota");
    }
    public IActionResult VelaColgante2() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/VelaColgante2");
    }
    public IActionResult Boombox() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/Boombox");
    }

    public IActionResult TrofeoDesfigurado() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/TrofeoDesfigurado");
    }

    public IActionResult Tacho() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/Tacho");
    }

    public IActionResult GameMachine1() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/GameMachine1");
    }

    public IActionResult GameMachine2() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/GameMachine2");
    }

    public IActionResult GameMachine3() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/GameMachine3");
    }

    public IActionResult GameMachine4() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/GameMachine4");
    }
    public IActionResult VerificarCodigo3(string codigo)
    {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        if (codigo.ToUpper() == "4ID")
        {
            ViewBag.nombre = HttpContext.Session.GetString("nombre");
            return View("SalaV/PreguntaFinal");
        }
        else
        {
            return View("SalaV/Error5");
        }
    }
    public IActionResult Error5() {
        ViewBag.segs = EstadoJuego.CuartoV.primeraPistaEncontrada == false ? 100 : 300;
        ViewBag.sala = "SalaV";
        return View("SalaV/Error5");
    }
    public IActionResult HistoriaIX() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("JefeFinal/HistoriaIX");
    }
    public IActionResult BossFight() {
        return View("JefeFinal/BossFight");
    }
    public IActionResult HistoriaX() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("JefeFinal/HistoriaX");
    }
    public IActionResult Creditos() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("FinalEpico/Creditos");
    }
}