namespace TP5_Hevia_ku.Models;
public class Sala {
   public List<Artefacto> cosas {get; set;} 
   public bool primeraPistaEncontrada { get; set; }
   public bool segundaPistaEncontrada { get; set; }
   public Sala(bool primeraPistaEncontrada, bool segundaPistaEncontrada)
   {
      cosas = new List<Artefacto>();
      this.primeraPistaEncontrada = primeraPistaEncontrada;
      this.segundaPistaEncontrada = segundaPistaEncontrada;
   }
   public void sumarArtefacto(string nombre, bool estado) {
      cosas.Add(new Artefacto(nombre, estado));
   }
}