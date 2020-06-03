using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
