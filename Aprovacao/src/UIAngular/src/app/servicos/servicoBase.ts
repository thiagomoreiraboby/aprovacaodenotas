import { Injectable, EventEmitter } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { throwError, BehaviorSubject, Observable} from 'rxjs';
import { usuario } from '../Model/usuario';
import { Alerta } from '../mensagem/mensagem.component';




@Injectable({
  providedIn: 'root'
})
export class servicoBase {

  caminhoApi = environment.API_URL;
  protected usuarioLogadoSubject: BehaviorSubject<usuario>;
  public usuarioLogado: usuario;
  public moduloadm: boolean;

  private static _mostarmensagem = new EventEmitter<Alerta>();

  static get mostarmensagem() {
    return servicoBase._mostarmensagem;
  }
  static set mostarmensagem(value) {
    servicoBase._mostarmensagem = value;
  }

  private static _autenticacaousuario = new EventEmitter<boolean>();

  static get autenticacaousuario() {
    return servicoBase._autenticacaousuario;
  }
  static set autenticacaousuario(value) {
    servicoBase._autenticacaousuario = value;
  }



  // Headers
  protected getHttpHeaders(): HttpHeaders{
    let header = new HttpHeaders().append('Content-Type', 'application/json');
    if(this.usuarioLogado != null){
      header = new HttpHeaders()
      .append("Content-Type", "application/json")
      .append("Authorization", "Bearer " +  this.usuarioLogado.tokenapi);
    }
    return header;
  }

constructor(protected httpClient: HttpClient) {
  this.usuarioLogadoSubject = new BehaviorSubject<usuario>(JSON.parse(sessionStorage.getItem('usuariologado')));
  this.usuarioLogadoSubject.subscribe((user: usuario)=> {
    if(user != null){
    this.usuarioLogado = user;
    if(user.papel == "Adm"){
      this.moduloadm = false;
    }
    else this.moduloadm = true;
  }
  });

}


handleError(error: HttpErrorResponse) {
  if(error.status == 401)
      this.logout();
  let errorMessage = '';
  if (error.error instanceof ErrorEvent) {
    errorMessage = error.error.message;
  } else {

    errorMessage = `Código do erro: ${error.status}\n ` + `menssagem: ${error.message}`;

  }
  return throwError(errorMessage);
};

logout() {
  sessionStorage.removeItem('usuariologado');
  this.usuarioLogadoSubject.next(null);
  servicoBase.autenticacaousuario.next(false);
}

emitirMensagemSucesso(mensagem){
  servicoBase.mostarmensagem.emit({
    type: 'success',
    message: mensagem,
  });
}

emitirMensagemErro(mensagem){
  servicoBase.mostarmensagem.emit({
    type: 'danger',
    message: mensagem,
  });
}


emitirMensagemAlerta(mensagem){
  servicoBase.mostarmensagem.emit({
    type: 'warning',
    message: mensagem,
  });
}


}
