import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PesquisanotasComponent } from './pesquisanotas/pesquisanotas.component';
import { LoginComponent } from './login/login.component';
import { AuthorizeGuard } from './autorizacaoApi/AuthorizeGuard';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'Autenticacao', component: LoginComponent },
  { path: 'notascompras', component: PesquisanotasComponent, canActivate: [AuthorizeGuard] },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
