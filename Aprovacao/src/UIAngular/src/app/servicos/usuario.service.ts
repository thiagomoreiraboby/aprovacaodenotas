import { Injectable } from '@angular/core';
import { servicoBase } from './servicoBase';
import { catchError, retry, map } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs';
import { usuario } from '../Model/usuario';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends servicoBase {

caminhoservico = this.caminhoApi+"/api/v1/Usuario/";
private usuarioLogadoSubject: BehaviorSubject<usuario>;
public usuarioLogado: Observable<usuario>;

constructor(private http: HttpClient) {
  super(http);
  this.usuarioLogadoSubject = new BehaviorSubject<usuario>(JSON.parse(sessionStorage.getItem('usuariologado')));
  this.usuarioLogado = this.usuarioLogadoSubject.asObservable();
}


autenticarApi(login, senha): Observable<any>{
  return this.httpClient.post<any>(this.caminhoservico+"Autenticar", JSON.stringify({login, senha}), this.httpOptions)
  .pipe(map(usua => {
    sessionStorage.setItem('usuariologado', JSON.stringify(usua));
    this.usuarioLogadoSubject.next(usua);
    return usua;
  }),
    catchError(this.handleError));
}

logout() {
  // remove user from local storage and set current user to null
  localStorage.removeItem('currentUser');
  this.usuarioLogadoSubject.next(null);
}

}
