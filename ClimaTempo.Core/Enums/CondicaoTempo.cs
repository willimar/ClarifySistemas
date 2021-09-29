using System.ComponentModel.DataAnnotations;

namespace ClimaTempo.Core.Enums
{
    public enum CondicaoTempo
    {
        [Display(Name = "Chuvoso")]
        chuvoso = 1,
        [Display(Name = "Nublado")]
        nublado = 2,
        [Display(Name = "Ensolarado")]
        ensolarado = 3,
        [Display(Name = "Instável")]
        instavel = 4,
        [Display(Name = "Tempestuoso")]
        tempestuoso = 5,
    }
}
