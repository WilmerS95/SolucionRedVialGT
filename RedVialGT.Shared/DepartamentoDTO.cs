using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedVialGT.Shared
{
    public class DepartamentoDTO
    {
        public int IdDepartamento { get; set; }

        public string NombreDepartamento { get; set; } = null!;

        public string NombreCabecera { get; set; } = null!;

        public double? DistanciaCapital { get; set; }

        public int? CantidadPoblacion { get; set; }

        public int? CantidadMunicipios { get; set; }

        public string? LugaresTuristicos { get; set; }

    }
}
