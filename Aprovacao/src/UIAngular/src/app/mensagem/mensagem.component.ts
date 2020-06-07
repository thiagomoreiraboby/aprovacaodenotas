import { Component, OnInit, Input } from '@angular/core';
import { servicoBase } from '../servicos/servicoBase';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';


export interface Alerta {
  type: string;
  message: string;

}

@Component({
  selector: 'app-mensagem',
  templateUrl: './mensagem.component.html'
})
export class MensagemComponent implements OnInit {
  private _mensagem = new Subject<Alerta>();
  alerta: Alerta;
  constructor() {

  }

  ngOnInit(): void {
    servicoBase.mostarmensagem.subscribe(
      (retorno: Alerta)=>{
        this._mensagem.next(retorno);
      }
    );
    this._mensagem.subscribe(retorno => this.alerta = retorno);
    this._mensagem.pipe(
      debounceTime(2000)
    ).subscribe(() => this.alerta = null);
  }

  ngOnDestroy (){
    servicoBase.mostarmensagem.unsubscribe();
    this._mensagem.unsubscribe();
  }

}
