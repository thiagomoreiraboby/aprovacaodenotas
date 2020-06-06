import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../servicos/usuario.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { usuario } from '../Model/usuario';

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

  constructor(
    private servico: UsuarioService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    ) { }

    mySubscription: any;

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({
      Usuario: ['', Validators.required],
      Senha: ['', Validators.required]
  });

  this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
  }

  get f() { return this.loginForm.controls; }

  onSubmit(){
    this.submitted = true;

    if (this.loginForm.invalid) {
      return;
  }
  this.loading = true;
    this.servico.autenticarApi(this.f.Usuario.value, this.f.Senha.value).subscribe(
      () => {
        this.router.navigate([this.returnUrl]);
        window.location.reload();
      },
      error =>{
        this.loading = false;
    });


  }

}
