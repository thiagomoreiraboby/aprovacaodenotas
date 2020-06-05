using System.ComponentModel;

namespace Aplicacao.Models
{
    public enum StatusNotaDTO
    {
        [Description("Visto")]
        Visto = 0,
        [Description("Aprovador")]
        Aprovador = 1
    }
}
