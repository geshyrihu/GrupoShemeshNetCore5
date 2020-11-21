

using System.ComponentModel.DataAnnotations;

namespace Administration.Enum
{
    public enum ERelationEmployee
    {
        [Display(Name = "Abuelos")]
        abuelos,
        [Display(Name = "Bisabuelos")]
        bisabuelos,
        [Display(Name = "Bisnietos")]
        bisnietos,
        [Display(Name = "Hermanos")]
        hermanos,
        [Display(Name = "Hijos")]
        hijos,
        [Display(Name = "Nietos")]
        nietos,
        [Display(Name = "Padres")]
        padres,
        [Display(Name = "Primos")]
        primos,
        [Display(Name = "Primos Sobrinos")]
        primossobrinos,
        [Display(Name = "Primos Tíos")]
        primostíos,
        [Display(Name = "Sobrinos")]
        sobrinos,
        [Display(Name = "Sobrinos Bisnietos")]
        sobrinosbisnietos,
        [Display(Name = "Sobrinos Nietos")]
        sobrinosnietos,
        [Display(Name = "Tatar Abuelos")]
        tatarabuelos,
        [Display(Name = "Tatara Nietos")]
        tataranietos,
        [Display(Name = "Tíos")]
        tíos,
        [Display(Name = "Tíos Abuelos")]
        tíosabuelos,
        [Display(Name = "Tíos Bisabuelos")]
        tíosbisabuelos,
        [Display(Name = "Trastatar Abuelos")]
        trastatarabuelos,
        [Display(Name = "Trastatara Nietos")]
        trastataranietos,

    }
}
