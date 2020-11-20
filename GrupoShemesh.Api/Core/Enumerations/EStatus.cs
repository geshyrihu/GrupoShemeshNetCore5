using System.ComponentModel.DataAnnotations;

namespace Administration.Enum
{
    public enum EStatus
    {
        Pendiente,
        Terminado,
        [Display(Name = "No autorizado")]
        noAutorizado
    }
}
