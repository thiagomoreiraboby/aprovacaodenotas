using System.ComponentModel;

namespace Aplicacao.Models
{
    public enum PapelAprovacaoDTO
    {
        [Description("Administrador")]
        Adm = 0,
        [Description("Visto")]
        Visto = 1,
        [Description("Aprovador")]
        Aprovador = 2
    }
}
