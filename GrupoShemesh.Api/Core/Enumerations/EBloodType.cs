

namespace Administration.Enum
{
    using System.ComponentModel.DataAnnotations;
    public enum EBloodType
    {
        [Display(Name = "O Negativo")]
        Type1 = 1,
        [Display(Name = "O positivo")]
        Type2 = 2,
        [Display(Name = "A negativo")]
        Type3 = 3,
        [Display(Name = "A positivo")]
        Type4 = 4,
        [Display(Name = "B negativo")]
        Type5 = 5,
        [Display(Name = "B positivo")]
        Type6 = 6,
        [Display(Name = "AB negativo")]
        Type7 = 7,
        [Display(Name = "AB positivo")]
        Type8 = 8

    }
}
