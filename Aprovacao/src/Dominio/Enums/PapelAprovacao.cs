using System.ComponentModel;

namespace Dominio.Enums
{
    public enum PapelAprovacao
    {
        [Description("Administrador")]
        Adm = 0,
        [Description("Visto")]
        Visto = 1,
        [Description("Aprovador")]
        Aprovador = 2
    }
}
