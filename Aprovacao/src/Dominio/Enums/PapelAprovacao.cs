using System.ComponentModel;

namespace Dominio.Enums
{
    public enum PapelAprovacao
    {
        [Description("Visto")]
        Visto = 0,
        [Description("Aprovador")]
        Aprovador = 1
    }
}
