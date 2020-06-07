import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenunavComponent } from './menunav/menunav.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { PesquisanotasComponent } from './pesquisanotas/pesquisanotas.component';
import { LoginComponent } from './login/login.component';
import { PesquisausuariosComponent } from './pesquisausuarios/pesquisausuarios.component';
import { MensagemComponent } from './mensagem/mensagem.component';





@NgModule({
  declarations: [
    AppComponent,
    MenunavComponent,
    HomeComponent,
    PesquisanotasComponent,
    LoginComponent,
    PesquisausuariosComponent,
    MensagemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
