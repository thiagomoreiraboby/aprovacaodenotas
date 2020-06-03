using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> where T:EntidadeBase
    {
        T Salvar(T Entidade);
        void Deletar(T Entidade);
        IEnumerable<T> ListarTodos();
        T Buscar(Guid id);

    }
}
