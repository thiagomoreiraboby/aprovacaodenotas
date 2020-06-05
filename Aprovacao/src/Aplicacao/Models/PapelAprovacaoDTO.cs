using System.ComponentModel;

namespace Aplicacao.Models
{
    public enum PapelAprovacaoDTO
    {
        [Description("Visto")]
        Visto = 0,
        [Description("Aprovador")]
        Aprovador = 1
    }
}
