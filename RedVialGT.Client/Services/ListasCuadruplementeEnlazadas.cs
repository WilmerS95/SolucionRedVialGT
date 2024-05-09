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

        public ListasCuadruplementeEnlazadas(IRutaService rutaService)
        {
            _rutaService = rutaService;
        }

        public async Task CrearNodosDesdeBD()
        {
            // Consultar la información de la base de datos para cada nodo
            nodoGuatemala.ruta = await ObtenerRutaDesdeBD(55);
            nodoBajaVerapaz.ruta = await ObtenerRutaDesdeBD(25);
            nodoAltaVerapaz.ruta = await ObtenerRutaDesdeBD(26);
            nodoPeten.ruta = await ObtenerRutaDesdeBD(27);
            nodoJalapa.ruta = await ObtenerRutaDesdeBD(28);
            nodoElProgreso.ruta = await ObtenerRutaDesdeBD(29);
            nodoZacapa.ruta = await ObtenerRutaDesdeBD(31);
            nodoIzabal.ruta = await ObtenerRutaDesdeBD(32);
            nodoChiquimula.ruta = await ObtenerRutaDesdeBD(34);
            nodoSantaRosa.ruta = await ObtenerRutaDesdeBD(36);
            nodoJutiapa.ruta = await ObtenerRutaDesdeBD(37);
            nodoSacatepequez.ruta = await ObtenerRutaDesdeBD(39);
            nodoEscuintla.ruta = await ObtenerRutaDesdeBD(40);
            nodoChimaltenango.ruta = await ObtenerRutaDesdeBD(42);
            nodoQuiche.ruta = await ObtenerRutaDesdeBD(43);
            nodoSolola.ruta = await ObtenerRutaDesdeBD(45);
            nodoTotonicapan.ruta = await ObtenerRutaDesdeBD(46);
            nodoQuetzaltenango.ruta = await ObtenerRutaDesdeBD(47);
            nodoSuchitepequez.ruta = await ObtenerRutaDesdeBD(48);
            nodoRetalhuleu.ruta = await ObtenerRutaDesdeBD(50);
            nodoSanMarcos.ruta = await ObtenerRutaDesdeBD(52);
            nodoHuehuetenango.ruta = await ObtenerRutaDesdeBD(53);

            await ConectarRedVial();
        }

        private async Task<Nodo> CrearNodoDesdeBD(int idRuta)
        {
            var ruta = await ObtenerRutaDesdeBD(idRuta);
            return new Nodo(ruta);
        }


        private async Task<RutaDTO> ObtenerRutaDesdeBD(int idRuta)
        {
            return await _rutaService.Buscar(idRuta);
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
    }
}