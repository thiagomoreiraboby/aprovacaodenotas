using Dominio.Enums;

namespace Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public Usuario()
        {

        }
        public Usuario(string login, string senha, decimal valorMinimo, decimal valorMaxino, PapelAprovacao papel)
        {
            GerarNovoId();
            Login = login;
            Senha = senha;
            ValorMinimo = valorMinimo;
            ValorMaxino = valorMaxino;
            Papel = papel;
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
        public decimal ValorMinimo { get; private set; }
        public decimal ValorMaxino { get; private set; }
        public PapelAprovacao Papel { get; private set; }
    }
}
