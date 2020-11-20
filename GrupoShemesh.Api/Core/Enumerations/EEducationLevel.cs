

namespace Administration.Enum
{
    using System.ComponentModel.DataAnnotations;
    public enum EEducationLevel
    {
        [Display(Name = "Preescolar")] Preescolar,
        [Display(Name = "Primaria")] Primaria,
        [Display(Name = "Secundaria")] Secundaria,
        [Display(Name = "Media Superior")] MediaSuperior,
        [Display(Name = "Bachillerato General")] BachilleratoGeneral,
        [Display(Name = "Profesional Técnica")] ProfesionalTécnica,
        [Display(Name = "Bachillerato Tecnológico")] BachilleratoTecnológico,
        [Display(Name = "Educación superior")] EducaciónSuperior

    }
}
