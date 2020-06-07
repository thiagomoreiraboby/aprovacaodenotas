import { Component, OnInit } from '@angular/core';
import { notasservice } from '../servicos/notas.service';
import { nota } from '../Model/nota';
import { NgbTypeaheadConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-pesquisanotas',
  templateUrl: './pesquisanotas.component.html',
  styleUrls: ['./pesquisanotas.component.css']
})
export class PesquisanotasComponent implements OnInit {

  nomepapel = "";
  notas: nota[];
  datainicio: Date;
  datafim: Date
  moduloadm
  constructor(private servico: notasservice) {

   }

  ngOnInit(): void {
    this.nomepapel = this.servico.usuarioLogado.papel;
    this.moduloadm = this.servico.moduloadm;
  }

  pesquisarNotas(){

    this.servico.pesquisarnotas(this.datainicio, this.datafim).subscribe(( retorno: nota[])=> {
      this.notas = retorno;
    })
  }


  limparpesquisa(){

    this.datainicio = null;
    this.datafim = null;
    this.notas = [];


  }
  aprovacaodeNotas(idNota): void {
    this.servico.aprovarnota(idNota).subscribe((retorno: boolean)=> {
        this.servico.emitirMensagemSucesso(`Operação de ${this.nomepapel} foi executada com sucesso!`)
        this.pesquisarNotas();

    },
      error => {
        this.servico.emitirMensagemAlerta(`Erro ao ${this.nomepapel} está nota!`)
      }
      );
  }

}
