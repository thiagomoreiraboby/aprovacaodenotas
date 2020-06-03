using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dominio.Enums
{
    public enum StatusNota
    {
        [Description("Pendente")]
        Pendente = 0,
        [Description("Aprovada")]
        Aprovada= 1
    }
}
