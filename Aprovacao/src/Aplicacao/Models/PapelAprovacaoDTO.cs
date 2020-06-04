using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
