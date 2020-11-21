using System.ComponentModel.DataAnnotations;

namespace Administration.Enum
{
    // ... Unidades de Medida
    public enum EMeasurementUnits
    {
        [Display(Name = "-")]
        None,
        Caja,
        Cajas,
        Cubeta,
        Cubetas,
        Cuñete,
        Cuñetes,
        Galón,
        Galones,
        Gramo,
        Gramos,
        Kilo,
        Kilos,
        Litro,
        Litros,
        Lote,
        Metro,
        [Display(Name = "Metro²")]
        MetroCuadrado,
        [Display(Name = "Metros²")]
        MetrosCuadrados,
        [Display(Name = "Metro³")]
        MetroCubico,
        [Display(Name = "Metros³")]
        MetrosCubicos,
        Metros,
        Pieza,
        Piezas,
        Rollo,
        Rollos,


    }
}
