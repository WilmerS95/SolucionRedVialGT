namespace RedVialGT.Server.Models;

public partial class Ruta
{
    public int IdRuta { get; set; }

    public string NombreRuta { get; set; } = null!;

    public int IdDepartamentoPartida { get; set; }

    public int IdDepartamentoDestino { get; set; }

    public double DistanciaDepartamentos { get; set; }

    public virtual Departamento IdDepartamentoDestinoNavigation { get; set; } = null!;

    public virtual Departamento IdDepartamentoPartidaNavigation { get; set; } = null!;
}
