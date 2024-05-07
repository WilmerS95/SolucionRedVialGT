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

        public Nodo(RutaDTO Ruta)
        {
            ligaOeste = null;
            ligaEste = null;
            ligaSur = null;
            ligaNorte = null;
            ruta = Ruta;
        }
    }
}
