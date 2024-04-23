using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RedVialGT.Shared
{
    public class RutaDTO
    {
        public int IdRuta { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string NombreRuta { get; set; } = null!;

        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdDepartamentoPartida { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdDepartamentoDestino { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double DistanciaDepartamentos { get; set; }

        public DepartamentoDTO? Departamento { get; set; }
    }
}
