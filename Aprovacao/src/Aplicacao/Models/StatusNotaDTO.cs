using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
