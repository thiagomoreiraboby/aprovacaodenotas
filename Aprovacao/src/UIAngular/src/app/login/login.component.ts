import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../servicos/usuario.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  Usuario: string;

  constructor(
    private servico: UsuarioService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    ) { }



  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Login: ['', Validators.required],
      Senha: ['', Validators.required]
  });

  this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.loginForm.controls; }

  onSubmit(){
    this.submitted = true;

    if (this.loginForm.invalid) {
      return;
  }
  this.loading = true;
    this.servico.autenticarApi(this.f.Login.value, this.f.Senha.value).subscribe(
      retorno => {
        this.Usuario = JSON.stringify(retorno);
        this.router.navigate([this.returnUrl]);
      },
      error =>{
        this.loading = false;
    });
  }

}
