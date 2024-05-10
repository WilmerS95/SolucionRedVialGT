using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RedVialGT.Shared
{
    //[TypeConverter(typeof(RutaDTOTypeConverter))]
    public class RutaDTO
    {
        public int IdRuta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreRuta { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdDepartamentoPartida { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdDepartamentoDestino { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double DistanciaDepartamentos { get; set; }

        public DepartamentoDTO? DepartamentoPartida { get; set; }
        public DepartamentoDTO? DepartamentoDestino { get; set; }
    }
}
