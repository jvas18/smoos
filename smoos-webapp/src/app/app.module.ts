import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterObraComponent } from './backoffice/components/register-obra/register-obra.component';
import { IndexSmoosComponent } from './index-smoos/index-smoos.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignUpPageComponent } from './sign-up-page/sign-up-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MultiSelectModule} from 'node_modules/primeng/multiselect';
import {PasswordModule} from 'node_modules/primeng/password';
import { RegisterArtistComponent } from './backoffice/components/register-artist/register-artist.component';
import { HeaderComponent } from './shared/header/header.component';
import {CalendarModule} from 'primeng/calendar';
import {RadioButtonModule} from 'primeng/radiobutton';

@NgModule({
  declarations: [
    AppComponent,
    RegisterObraComponent,
    IndexSmoosComponent,
    LoginPageComponent,
    SignUpPageComponent,
    RegisterArtistComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    PasswordModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatIconModule,
    MultiSelectModule,
    CalendarModule, 
    RadioButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
