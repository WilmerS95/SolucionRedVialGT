using RedVialGT.Shared;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedVialGT.Client.Services
{
    public class ListasCuadruplementeEnlazadas
    {
        private readonly IRutaService _rutaService;

        public Nodo? primerNodo { get; set; }
        public Nodo? ultimoNodoNorte { get; set; }
        public Nodo? ultimoNodoSur { get; set; }
        public Nodo? ultimoNodoEste { get; set; }
        public Nodo? ultimoNodoOeste { get; set; }
        public Nodo? nodoActual { get; set; }

        public bool isEmpty => primerNodo == null;

        public ListasCuadruplementeEnlazadas(IRutaService rutaService)
        {
            _rutaService = rutaService;
            primerNodo = null;
            ultimoNodoNorte = null;
            ultimoNodoSur = null;
            ultimoNodoEste = null;
            ultimoNodoOeste = null;
            nodoActual = null;
        }

        public async Task<string> InsertarPrimerNodoDesdeBD()
        {
            if (isEmpty)
            {
                // Obtener una ruta de la base de datos
                var rutas = await _rutaService.ListaDestino(); // Asumiendo que IRutaService tiene un método para obtener las rutas
                var primeraRuta = rutas.FirstOrDefault(); // Obtener la primera ruta (o puedes elegir otra lógica para seleccionarla)

                if (primeraRuta != null)
                {
                    // Crear el nodo con la ruta obtenida
                    primerNodo = new Nodo(primeraRuta);
                    ultimoNodoNorte = primerNodo;
                    ultimoNodoSur = primerNodo;
                    ultimoNodoEste = primerNodo;
                    ultimoNodoOeste = primerNodo;

                    return "Se ha agregado el primer nodo de la lista con la ruta obtenida de la base de datos";
                }
                else
                {
                    return "No se encontraron rutas en la base de datos para agregar como primer nodo";
                }
            }
            else
            {
                return "No se puede agregar el primer nodo a la lista porque ya existen nodos";
            }
        }
    }
}