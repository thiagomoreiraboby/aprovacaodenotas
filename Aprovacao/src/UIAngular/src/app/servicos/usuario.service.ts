import { Injectable } from '@angular/core';
import { servicoBase } from './servicoBase';
import { catchError, retry, map } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends servicoBase {

caminhoservico = this.caminhoApi+"/api/v1/Usuario/";


autenticarApi(login, senha): Observable<any>{
  return this.httpClient.post<any>(this.caminhoservico+"Autenticar", JSON.stringify({login, senha}), {headers: this.getHttpHeaders()})
  .pipe(map(usua => {
      sessionStorage.setItem('usuariologado', JSON.stringify(usua));
      this.usuarioLogadoSubject.next(usua);
    return usua;
  }),
    catchError(this.handleError)
    );
}



pesquisartodos(): Observable<any[]>{
  return this.httpClient.get<any[]>(this.caminhoservico, { headers: this.getHttpHeaders()} )
  .pipe(
    catchError(this.handleError));
}

}
