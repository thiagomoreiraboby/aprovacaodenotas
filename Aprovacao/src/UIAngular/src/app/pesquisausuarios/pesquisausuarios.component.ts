import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../servicos/usuario.service';
import { usuariodto } from '../Model/usuariodto';


@Component({
  selector: 'app-pesquisausuarios',
  templateUrl: './pesquisausuarios.component.html',
  styleUrls: ['./pesquisausuarios.component.css']
})
export class PesquisausuariosComponent implements OnInit {

  usuarios: usuariodto[];
  constructor(private servico: UsuarioService) {

   }



  ngOnInit(): void {

  }

  pesquisar(){

    this.servico.pesquisartodos().subscribe(( retorno: usuariodto[])=> {
      this.usuarios = retorno;
    })
  }

}
