import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UsuarioService } from '../servicos/usuario.service';
import { Router, NavigationEnd } from '@angular/router';
import { servicoBase } from '../servicos/servicoBase';

@Component({
  selector: 'app-menunav',
  templateUrl: './menunav.component.html',
  styleUrls: ['./menunav.component.css']
})
export class MenunavComponent implements OnInit {

  logout: boolean;
  NomeUsuario: string;
  caminhoswagger = environment.API_URL + "/swagger/index.html";
  moduloadm: boolean;

  constructor(private servico: UsuarioService, private router: Router) {

   }

  ngOnInit(): void {
    servicoBase.autenticacaousuario.subscribe(
      (retorno: boolean)=>{
          this.ValidarUsuario();
        }
      
    );

      this.ValidarUsuario();
  }

  private ValidarUsuario() {
    if (this.servico.usuarioLogado != null) {
      this.logout = false;
      this.NomeUsuario = this.servico.usuarioLogado.nome;
      this.moduloadm = this.servico.moduloadm;
    }
    else {
      this.logout = true;
      this.NomeUsuario = "";
    }
  }

  LogoutSistema(){
    this.servico.logout();
    this.logout = false;
    this.router.navigate([""]);

  }

  ngOnDestroy (){
  }

}
