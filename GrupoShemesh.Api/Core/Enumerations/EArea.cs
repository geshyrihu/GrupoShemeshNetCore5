using System.ComponentModel.DataAnnotations;


namespace Administration.Enum
{
    public enum EArea
    {
        Administración,
        Mantenimiento,
        Limpieza,
        [Display(Name = "Seguridad Interna")]
        SeguridadInterna,
        [Display(Name = "Seguridad Externa")]
        SeguridadExterna,
        Jardineria,
        [Display(Name = "Valet Parking")]
        ValetParkig,
        Consergeria,
        Externo,
        Ludoteca,
        Sistemas,

    }
}
