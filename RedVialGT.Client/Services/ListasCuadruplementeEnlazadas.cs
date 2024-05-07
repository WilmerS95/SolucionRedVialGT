using RedVialGT.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedVialGT.Client.Services
{
    public class ListasCuadruplementeEnlazadas
    {
        public Nodo? primerNodo { get; set; }
        public Nodo? ultimoNodoNorte { get; set; }
        public Nodo? ultimoNodoSur { get; set; }
        public Nodo? ultimoNodoEste { get; set; }
        public Nodo? ultimoNodoOeste { get; set; }
        public Nodo? nodoActual { get; set; }

        public bool isEmpty => primerNodo == null;

        public ListasCuadruplementeEnlazadas()
        {
            primerNodo = null;
            ultimoNodoNorte = null;
            ultimoNodoSur = null;
            ultimoNodoEste = null;
            ultimoNodoOeste = null;
            nodoActual = null;
        }

        public string InsertarPrimerNodo(RutaDTO ruta)
        {
            Nodo nuevoNodo = new Nodo(ruta);
            if (isEmpty)
            {
                primerNodo = nuevoNodo;
                ultimoNodoNorte = nuevoNodo;
                ultimoNodoSur = nuevoNodo;
                ultimoNodoEste = nuevoNodo;
                ultimoNodoOeste = nuevoNodo;

                return "Se ha agregado el primer nodo de la lista";
            }
            else
            {
                return "No se puede agregar primer nodo a la lista, porque ya existen nodos";
            }
        }
    }
}