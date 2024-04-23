using System;
using System.Collections.Generic;

namespace RedVialGT.Server.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public string NombreCabecera { get; set; } = null!;

    public double? DistanciaCapital { get; set; }

    public int? CantidadPoblacion { get; set; }

    public int? CantidadMunicipios { get; set; }

    public string? LugaresTuristicos { get; set; }

    public virtual ICollection<Ruta> RutaIdDepartamentoDestinoNavigations { get; set; } = new List<Ruta>();

    public virtual ICollection<Ruta> RutaIdDepartamentoPartidaNavigations { get; set; } = new List<Ruta>();
}
