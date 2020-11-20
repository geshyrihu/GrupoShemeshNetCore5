

namespace Administration.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum EPositionAdministration
    {
        Dirección, 
        Supervisión, 
        Residente, 
        Contador,
        Asistente,
        [Display(Name = "Recursos H.")]
        RecursosHuamanos,
        [Display(Name = "Jefe de Mantenimiento")]
        JefeDeMantenimiento,
        Abogado,
        Sistemas

    }
}
