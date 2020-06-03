using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; set; }


        public void GerarNovoId()
        {
            Id = Guid.NewGuid();
        }
    }
}
