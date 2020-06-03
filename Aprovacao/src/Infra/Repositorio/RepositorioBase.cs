using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        public T Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(T Entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public T Salvar(T Entidade)
        {
            throw new NotImplementedException();
        }
    }
}
