using TP5_Hevia_ku.Models;

namespace TP05_Hevia_ku.Models;

public static class EstadoJuego
{
    public static Sala CuartoI { get; private set; }

    static EstadoJuego()
    {
        // Inicializar el cuarto I con sus artefactos
        CuartoI = new Sala(false);
        CuartoI.sumarArtefacto("Cofre", true);
        CuartoI.sumarArtefacto("Libro", true);
        CuartoI.sumarArtefacto("Puerta", false);
        CuartoI.sumarArtefacto("Velas", true);
        CuartoI.sumarArtefacto("Cruz", false);
        CuartoI.sumarArtefacto("Adorno", true);
        CuartoI.sumarArtefacto("Cuadro1", false);
        CuartoI.sumarArtefacto("Cuadro2", false);
    }

    public static void CambiarEstadoArtefacto(int indice, bool nuevoEstado)
    {
        if (indice >= 0 && indice < CuartoI.cosas.Count)
        {
            CuartoI.cosas[indice].estadoDeMaterial = nuevoEstado;
        }
    }
} 