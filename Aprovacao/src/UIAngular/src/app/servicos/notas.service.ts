import { Injectable } from '@angular/core';
import { servicoBase } from './servicoBase';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class notasservice extends servicoBase {

caminhoservico = this.caminhoApi+"/api/v1/Notas";

aprovarnota(idNota): Observable<any>{
  var idUsuario = this.usuarioLogado.codigo;

  return this.httpClient.post<any>(this.caminhoservico, JSON.stringify({idUsuario, idNota}), {headers: this.getHttpHeaders()})
  .pipe(
    catchError(this.handleError));
}


pesquisarnotas(dataIncio?, dataFim?): Observable<any[]>{
  let parametros = new HttpParams();
  parametros = parametros.append('idUsuario', this.usuarioLogado.codigo);
  if(dataIncio != null && dataFim != null){
  parametros = parametros.append('dataIncio', dataIncio);
  parametros = parametros.append('dataFim', dataFim);
  }
  return this.httpClient.get<any[]>(this.caminhoservico, { headers: this.getHttpHeaders(), params: parametros} )
  .pipe(
    catchError(this.handleError));
}


}
