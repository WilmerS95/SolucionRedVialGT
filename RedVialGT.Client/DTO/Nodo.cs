using RedVialGT.Shared;

namespace RedVialGT.Client.DTO
{
    public class Nodo
    {
        public Nodo? ligaOeste { get; set; }
        public Nodo? ligaEste { get; set;}
        public Nodo? ligaSur {  get; set; }
        public Nodo? ligaNorte { get; set; }
        public RutaDTO ruta { get; set; }

        public Nodo(RutaDTO ruta)
        {
            this.ligaOeste = ligaOeste;
            this.ligaEste = ligaEste;
            this.ligaSur = ligaSur;
            this.ligaNorte = ligaNorte;
            this.ruta = ruta;
        }
    }
}
