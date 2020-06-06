import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { throwError, BehaviorSubject, Observable} from 'rxjs';
import { usuario } from '../Model/usuario';



@Injectable({
  providedIn: 'root'
})
export class servicoBase {

  caminhoApi = environment.API_URL;
  protected usuarioLogadoSubject: BehaviorSubject<usuario>;
  public usuarioLogado: usuario;
  public moduloadm: boolean;



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
    this.usuarioLogado = user;
    if(user.papel == "Adm"){
      this.moduloadm = false;
    }
    else this.moduloadm = true;
  });

}


handleError(error: HttpErrorResponse) {
  let errorMessage = '';
  if (error.error instanceof ErrorEvent) {
    errorMessage = error.error.message;
  } else {
    errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
  }
  console.log(errorMessage);
  return throwError(errorMessage);
};
}
