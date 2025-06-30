using AspNetCoreGeneratedDocument;
using TP5_Hevia_ku.Models;

namespace TP05_Hevia_ku.Models;

public static class EstadoJuego
{
    public static Sala CuartoI { get; private set; }
    public static Sala CuartoIII { get; private set; }
    public static Sala CuartoV { get; private set; }

    static EstadoJuego()
    {
        // Inicializar el cuarto I con sus artefactos
        CuartoI = new Sala(false, false);
        CuartoI.sumarArtefacto("Cofre", true);
        CuartoI.sumarArtefacto("Libro", true);
        CuartoI.sumarArtefacto("Puerta", false);
        CuartoI.sumarArtefacto("Velas", true);
        CuartoI.sumarArtefacto("Cruz", false);
        CuartoI.sumarArtefacto("Adorno", true);
        CuartoI.sumarArtefacto("Cuadro1", false);
        CuartoI.sumarArtefacto("Cuadro2", false);

        CuartoIII = new Sala(false, false);
        CuartoIII.sumarArtefacto("Cajon1", true);
        CuartoIII.sumarArtefacto("Cajon2", false);
        CuartoIII.sumarArtefacto("Cajon3", false);
        CuartoIII.sumarArtefacto("Puerta", false);
        CuartoIII.sumarArtefacto("PuertaM1", false);
        CuartoIII.sumarArtefacto("PuertaM2", false);
        CuartoIII.sumarArtefacto("Lista", true);
        CuartoIII.sumarArtefacto("Caldera", false);
        CuartoIII.sumarArtefacto("VelaColgada", true);
        CuartoIII.sumarArtefacto("Vasija", true);

        CuartoV = new Sala(false, false);
        CuartoV.sumarArtefacto("Tacho", true);
        CuartoV.sumarArtefacto("Nota", true);
        CuartoV.sumarArtefacto("VelaColgante2", true);
        CuartoV.sumarArtefacto("Lista2", true);
        CuartoV.sumarArtefacto("Boombox", true);
        CuartoV.sumarArtefacto("TrofeoDesfigurado", true);
        CuartoV.sumarArtefacto("Puerta", false);
        CuartoV.sumarArtefacto("GameMachine1", false);
        CuartoV.sumarArtefacto("GameMachine2", false);
        CuartoV.sumarArtefacto("GameMachine3", false);
        CuartoV.sumarArtefacto("GameMachine4", false);
    }

    public static void CambiarEstadoArtefacto(int indice, bool nuevoEstado)
    {
        if (indice >= 0 && indice < CuartoI.cosas.Count)
        {
            CuartoI.cosas[indice].estadoDeMaterial = nuevoEstado;
        }
    }
} 