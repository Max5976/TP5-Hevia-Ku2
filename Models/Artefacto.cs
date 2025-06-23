namespace TP5_Hevia_ku.Models;
public class Artefacto {
    public string nombre {get; set;}
    public bool estadoDeMaterial {get; set;}

    public Artefacto(string nombre, bool estadoDeMaterial) {
        this.nombre = nombre;
        this.estadoDeMaterial = estadoDeMaterial;
    }
    public bool cambiarEstado(bool estado) {
        if (estado == false) {
            estado = true;
        }
        else {
            estado = false;
        }
        return estado;
    }
}
