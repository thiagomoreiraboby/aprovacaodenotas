import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UsuarioService } from '../servicos/usuario.service';

@Injectable({ providedIn: 'root' })
export class AuthorizeGuard implements CanActivate {
    constructor(
        private router: Router,
        private usuario: UsuarioService
    ) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.usuario.usuarioLogado;
        if (currentUser) {
            // authorised so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/Autenticacao'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}
