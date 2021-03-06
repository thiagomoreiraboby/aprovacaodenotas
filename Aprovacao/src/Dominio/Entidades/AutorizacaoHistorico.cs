﻿using Dominio.Enums;
using System;

namespace Dominio.Entidades
{
    public class AutorizacaoHistorico : EntidadeBase
    {
        public AutorizacaoHistorico()
        {
            Usuario = new Usuario();
            Nota = new NotadeCompra();
        }
        public AutorizacaoHistorico(DateTime data, Usuario usuario, NotadeCompra nota, PapelAprovacao papel)
        {
            GerarNovoId();
            Data = data;
            Usuario = usuario;
            Nota = nota;
            Papel = papel;
        }

        public DateTime Data { get; private set; }
        public Usuario Usuario { get; private set; }
        public NotadeCompra Nota { get; private set; }
        public PapelAprovacao Papel { get; private set; }
    }
}
