using RedVialGT.Shared;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedVialGT.Client.Services
{
    public class ListasCuadruplementeEnlazadas
    {
        private readonly IRutaService _rutaService;

        public Nodo? nodoGuatemala { get; set; }
        public Nodo? nodoSantaRosa { get; set; }
        public Nodo? nodoSacatepequez { get; set; }
        public Nodo? nodoJalapa { get; set; }
        public Nodo? nodoBajaVerapaz { get; set; }
        public Nodo? nodoPeten { get; set; }
        public Nodo? nodoAltaVerapaz { get; set; }
        public Nodo? nodoElProgreso { get; set; }
        public Nodo? nodoZacapa { get; set; }
        public Nodo? nodoIzabal { get; set; }
        public Nodo? nodoChiquimula { get; set; }
        public Nodo? nodoJutiapa { get; set; }
        public Nodo? nodoEscuintla { get; set; }
        public Nodo? nodoChimaltenango { get; set; }
        public Nodo? nodoQuiche { get; set; }
        public Nodo? nodoHuehuetenango { get; set; }
        public Nodo? nodoSolola { get; set; }
        public Nodo? nodoTotonicapan { get; set; }
        public Nodo? nodoQuetzaltenango { get; set; }
        public Nodo? nodoSuchitepequez { get; set; }
        public Nodo? nodoRetalhuleu { get; set; }
        public Nodo? nodoSanMarcos { get; set; }
        //public Nodo? nodo2BajaVerapaz {  get; set; }
        //public Nodo? nodo2AltaVerapaz { get; set; }
        //public Nodo? nodo2Zacapa { get; set; }
        //public Nodo? nodo2Jalapa { get; set; }
        //public Nodo? nodo2Sacatepequez { get; set; }
        //public Nodo? nodo3AltaVerapaz { get; set; }
        //public Nodo? nodo2Solola { get; set; }
        //public Nodo? nodo2Quetzaltenango { get; set; }
        //public Nodo? nodo2Quiche { get; set; }

        public ListasCuadruplementeEnlazadas(IRutaService rutaService)
        {
            _rutaService = rutaService;

            nodoGuatemala = new Nodo();
            nodoSantaRosa = new Nodo();
            nodoJutiapa = new Nodo();
            nodoJalapa = new Nodo();
            nodoChiquimula = new Nodo();
            nodoZacapa = new Nodo();
            nodoIzabal = new Nodo();
            nodoElProgreso = new Nodo();
            nodoBajaVerapaz = new Nodo();
            nodoAltaVerapaz = new Nodo();
            nodoPeten = new Nodo();
            nodoQuiche = new Nodo();
            nodoHuehuetenango = new Nodo();
            nodoSanMarcos = new Nodo();
            nodoRetalhuleu = new Nodo();
            nodoQuetzaltenango = new Nodo();
            nodoSuchitepequez = new Nodo();
            nodoEscuintla = new Nodo();
            nodoSolola = new Nodo();
            nodoTotonicapan = new Nodo();
            nodoChimaltenango = new Nodo();
            nodoSacatepequez = new Nodo();
        }

        public async Task CrearNodosDesdeBD()
        {
            // Consultar la información de la base de datos para cada nodo
            nodoGuatemala.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 55 });     //Guatemala - Guatemala
            nodoBajaVerapaz.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 25 });    //Guatemala - Baja Verapaz
            nodoAltaVerapaz.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 26 });    //Baja Verapaz - Alta Verapaz
            nodoPeten.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 27 });          //Alta verapaz - Peten
            nodoJalapa.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 28 });         //Guatemala - Jalapa
            nodoElProgreso.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 29 });     //Jalapa - El Progreso
            //nodo2BajaVerapaz.ruta = await ObtenerRutaDesdeBD(30);   //El Progreso - Baja Verapaz
            nodoZacapa.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 31 });         //El Progreso - Zacapa
            nodoIzabal.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 32 });         //Zacapa - Izabal
            //nodo2AltaVerapaz.ruta = await ObtenerRutaDesdeBD(33);   //Izabal - Alta Verapaz
            nodoChiquimula.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 34 });     //Jalapa - Chiquimula
            //nodo2Zacapa.ruta = await ObtenerRutaDesdeBD(35);        //Chiquimula - Zacapa
            nodoSantaRosa.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 36 });      //Guatemala - Santa Rosa
            nodoJutiapa.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 37 });        //Santa Rosa - Jutiapa
            //nodo2Jalapa.ruta = await ObtenerRutaDesdeBD(38);        //Jutiapa - Jalapa
            nodoSacatepequez.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 39 });   //Guatemala - Sacatepequez
            nodoEscuintla.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 40 });      //Santa Rosa - Escuintla
            //nodo2Sacatepequez.ruta = await ObtenerRutaDesdeBD(41);  //Escuintla - Sacatepequez
            nodoChimaltenango.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 42 });  //Sacatepequez - Chimaltenango
            nodoQuiche.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 43 });         //Chimaltenango - Quiché
            //nodo3AltaVerapaz.ruta = await ObtenerRutaDesdeBD(44);   //Quiché - Alta Verapaz
            nodoSolola.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 45 });         //Chimaltenango - Sololá
            nodoTotonicapan.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 46 });    //Sololá - Totonicapan
            nodoQuetzaltenango.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 47 }); //Sololá - Quetzaltenango
            nodoSuchitepequez.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 48 });  //Escuintla - Suchitepequez
            //nodo2Solola.ruta = await ObtenerRutaDesdeBD(49);        //Suchitepequez - Solola
            nodoRetalhuleu.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 50 });     //Suchitepequez - Retalhuleu
            //nodo2Quetzaltenango.ruta = await ObtenerRutaDesdeBD(51);//Retalhuleu - Quetzaltenango
            nodoSanMarcos.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 52 });      //Retalhuleu - San Marcos
            nodoHuehuetenango.ruta = await ObtenerRutaDesdeBD(new RutaDTO { IdRuta = 53 });  //San Marcos - Huehuetenango
            //nodo2Quiche.ruta = await ObtenerRutaDesdeBD(54);        //Huehuetenango - Quiche

            await ConectarRedVial();
        }

        //private async Task<Nodo> CrearNodoDesdeBD(RutaDTO idRuta)
        //{
        //    var ruta = await ObtenerRutaDesdeBD(idRuta);
        //    return new Nodo(ruta);
        //}




        private async Task<RutaDTO> ObtenerRutaDesdeBD(RutaDTO ruta)
        {
            return await _rutaService.Buscar(ruta.IdRuta);
        }

        public async Task ConectarRedVial()
        {
            //01 Guatemala
            if (nodoGuatemala != null)
            {
                nodoGuatemala.ligaSur = nodoSantaRosa;
                nodoGuatemala.ligaEste = nodoJalapa;
                nodoGuatemala.ligaNorte = nodoBajaVerapaz;
                nodoGuatemala.ligaOeste = nodoSacatepequez;
            }

            //02 El Progreso
            if (nodoElProgreso != null)
            {
                nodoElProgreso.ligaSur = nodoJalapa;
                nodoElProgreso.ligaEste = nodoZacapa;
                nodoElProgreso.ligaOeste = nodoBajaVerapaz;
            }

            //03 Sacatepequez
            if (nodoSacatepequez != null)
            {
                nodoSacatepequez.ligaSur = nodoEscuintla;
                nodoSacatepequez.ligaEste = nodoGuatemala;
                nodoSacatepequez.ligaOeste = nodoChimaltenango;
            }

            //04 Chimaltenango
            if (nodoChimaltenango != null)
            {
                nodoChimaltenango.ligaNorte = nodoQuiche;
                nodoChimaltenango.ligaEste = nodoSacatepequez;
                nodoChimaltenango.ligaOeste = nodoSolola;
            }

            //05 Escuintla
            if (nodoEscuintla != null)
            {
                nodoEscuintla.ligaNorte = nodoSacatepequez;
                nodoEscuintla.ligaEste = nodoSantaRosa;
                nodoEscuintla.ligaOeste = nodoSuchitepequez;
            }

            //06 Santa Rosa
            if (nodoSantaRosa != null)
            {
                nodoSantaRosa.ligaNorte = nodoGuatemala;
                nodoSantaRosa.ligaEste = nodoJutiapa;
                nodoSantaRosa.ligaOeste = nodoEscuintla;
            }

            //07 Solola
            if (nodoSolola != null)
            {
                nodoSolola.ligaSur = nodoSuchitepequez;
                nodoSolola.ligaNorte = nodoTotonicapan;
                nodoSolola.ligaEste = nodoChimaltenango;
                nodoSolola.ligaOeste = nodoQuetzaltenango;
            }

            //08 Totonicapan
            if (nodoTotonicapan != null)
            {
                nodoTotonicapan.ligaSur = nodoSolola;
            }

            //09 Quetzaltenango
            if (nodoQuetzaltenango != null)
            {
                nodoQuetzaltenango.ligaSur = nodoRetalhuleu;
                nodoQuetzaltenango.ligaEste = nodoSolola;
            }

            //10 Suchitepequez
            if (nodoSuchitepequez != null)
            {
                nodoSuchitepequez.ligaNorte = nodoSolola;
                nodoSuchitepequez.ligaEste = nodoEscuintla;
                nodoSuchitepequez.ligaOeste = nodoRetalhuleu;
            }

            //11 Retalhuleu
            if (nodoRetalhuleu != null)
            {
                nodoRetalhuleu.ligaEste = nodoSuchitepequez;
                nodoRetalhuleu.ligaOeste = nodoSanMarcos;
                nodoRetalhuleu.ligaNorte = nodoQuetzaltenango;
            }

            //12 San Marcos
            if (nodoSanMarcos != null)
            {
                nodoSanMarcos.ligaEste = nodoRetalhuleu;
                nodoSanMarcos.ligaNorte = nodoHuehuetenango;
            }

            //13 Huehuetenango
            if (nodoHuehuetenango != null)
            {
                nodoHuehuetenango.ligaSur = nodoSanMarcos;
                nodoHuehuetenango.ligaEste = nodoQuiche;
            }

            //14 Quiché
            if (nodoQuiche != null)
            {
                nodoQuiche.ligaSur = nodoChimaltenango;
                nodoQuiche.ligaOeste = nodoHuehuetenango;
                nodoQuiche.ligaEste = nodoAltaVerapaz;
            }

            //15 Baja Verapaz
            if (nodoBajaVerapaz != null)
            {
                nodoBajaVerapaz.ligaSur = nodoGuatemala;
                nodoBajaVerapaz.ligaEste = nodoElProgreso;
                nodoBajaVerapaz.ligaNorte = nodoAltaVerapaz;
            }

            //16 Alta Verapaz
            if (nodoAltaVerapaz != null)
            {
                nodoAltaVerapaz.ligaSur = nodoBajaVerapaz;
                nodoAltaVerapaz.ligaNorte = nodoPeten;
                nodoAltaVerapaz.ligaEste = nodoIzabal;
                nodoAltaVerapaz.ligaOeste = nodoQuiche;
            }

            //17 Petén
            if (nodoPeten != null)
            {
                nodoPeten.ligaSur = nodoAltaVerapaz;
            }

            //18 Izabal
            if (nodoIzabal != null)
            {
                nodoIzabal.ligaOeste = nodoAltaVerapaz;
                nodoIzabal.ligaSur = nodoZacapa;
            }

            //19 Zacapa
            if (nodoZacapa != null)
            {
                nodoZacapa.ligaNorte = nodoIzabal;
                nodoZacapa.ligaOeste = nodoElProgreso;
                nodoZacapa.ligaSur = nodoChiquimula;
            }

            //20 Chiquimula
            if (nodoChiquimula != null)
            {
                nodoChiquimula.ligaNorte = nodoZacapa;
                nodoChiquimula.ligaOeste = nodoJalapa;
            }

            //21 Jalapa
            if (nodoJalapa != null)
            {
                nodoJalapa.ligaNorte = nodoElProgreso;
                nodoJalapa.ligaSur = nodoJutiapa;
                nodoJalapa.ligaEste = nodoChiquimula;
                nodoJalapa.ligaOeste = nodoGuatemala;
            }

            //22 Jutiapa
            if (nodoJutiapa != null)
            {
                nodoJutiapa.ligaNorte = nodoJalapa;
                nodoJutiapa.ligaOeste = nodoSantaRosa;
            }
        }
        public List<Nodo> ObtenerListaNodos()
        {
            var listaNodos = new List<Nodo?>();
            // Agregar todos los nodos a la lista
            listaNodos.Add(nodoGuatemala);
            listaNodos.Add(nodoElProgreso);
            listaNodos.Add(nodoSacatepequez);
            listaNodos.Add(nodoChimaltenango);
            listaNodos.Add(nodoEscuintla);
            listaNodos.Add(nodoSantaRosa);
            listaNodos.Add(nodoSolola);
            listaNodos.Add(nodoTotonicapan);
            listaNodos.Add(nodoQuetzaltenango);
            listaNodos.Add(nodoSuchitepequez);
            listaNodos.Add(nodoRetalhuleu);
            listaNodos.Add(nodoSanMarcos);
            listaNodos.Add(nodoHuehuetenango);
            listaNodos.Add(nodoQuiche);
            listaNodos.Add(nodoBajaVerapaz);
            listaNodos.Add(nodoAltaVerapaz);
            listaNodos.Add(nodoPeten);
            listaNodos.Add(nodoIzabal);
            listaNodos.Add(nodoZacapa);
            listaNodos.Add(nodoChiquimula);
            listaNodos.Add(nodoJalapa);
            listaNodos.Add(nodoJutiapa);

            return listaNodos.Where(n => n != null).ToList();
        }

        public List<Nodo> RecorrerListaEntreDepartamentos(RutaDTO rutaPartida, RutaDTO rutaDestino)
        {
            var nodoPartida = BuscarNodoPorRuta(rutaPartida);
            var nodoDestino = BuscarNodoPorRuta(rutaDestino);

            if (nodoPartida == null || nodoDestino == null)
                return new List<Nodo>();

            var rutasEncontradas = new List<List<Nodo>>();
            var visitados = new HashSet<Nodo>();
            var cola = new Queue<(Nodo, List<Nodo>)>();
            cola.Enqueue((nodoPartida, new List<Nodo> { nodoPartida }));

            while (cola.Count > 0)
            {
                var (nodoActual, ruta) = cola.Dequeue();
                if (nodoActual == nodoDestino)
                {
                    rutasEncontradas.Add(ruta);
                    continue;
                }

                if (visitados.Contains(nodoActual))
                    continue;

                visitados.Add(nodoActual);

                foreach (var liga in ObtenerTodasLasLigas(nodoActual))
                {
                    var nuevaRuta = new List<Nodo>(ruta);
                    nuevaRuta.Add(liga);
                    cola.Enqueue((liga, nuevaRuta));
                }
            }

            return rutasEncontradas.SelectMany(r => r).Distinct().ToList();
        }

        private IEnumerable<Nodo> ObtenerTodasLasLigas(Nodo nodo)
        {
            var ligas = new List<Nodo>();
            if (nodo.ligaNorte != null)
                ligas.Add(nodo.ligaNorte);
            if (nodo.ligaSur != null)
                ligas.Add(nodo.ligaSur);
            if (nodo.ligaEste != null)
                ligas.Add(nodo.ligaEste);
            if (nodo.ligaOeste != null)
                ligas.Add(nodo.ligaOeste);
            return ligas;
        }

        public Nodo? BuscarNodoPorRuta(RutaDTO ruta)
        {
            var listaNodos = ObtenerListaNodos();
            return listaNodos.FirstOrDefault(n => n != null && n.ruta != null && n.ruta.IdRuta == ruta.IdRuta);
        }
    }
}