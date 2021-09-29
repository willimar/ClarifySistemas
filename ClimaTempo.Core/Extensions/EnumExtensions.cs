using ClimaTempo.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ClimaTempo.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
    {
        DisplayAttribute displayAttribute = value.GetType()
                                             .GetMember(value.ToString())
                                             .FirstOrDefault()?
                                             .GetCustomAttribute<DisplayAttribute>();

        string displayName = displayAttribute?.GetName();

        return displayName;
    }

    public static string GetNomeTempo(this CondicaoTempo value)
    {
        switch (value)
        {
            case CondicaoTempo.chuvoso:
                return "fa-cloud-showers-heavy";
            case CondicaoTempo.nublado:
                return "fa-cloud";
            case CondicaoTempo.ensolarado:
                return "fa-sun";
            case CondicaoTempo.instavel:
                return "fa-cloud-sun";
            case CondicaoTempo.tempestuoso:
                return "fa-poo-storm";
            default:
                return string.Empty;
        }
    }
}
}
