using System.ComponentModel;

namespace Aplicacao.Models
{
    public enum StatusNotaDTO
    {
        [Description("Pendente")]
        Pendente = 0,
        [Description("Aprovada")]
        Aprovada = 1
    }
}
