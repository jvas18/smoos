import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexSmoosComponent } from './backoffice/components/index-smoos/index-smoos.component';
import { LoginPageComponent } from './backoffice/components/login-page/login-page.component';
import { RegisterArtistComponent } from './backoffice/components/register-artist/register-artist.component';
import { RegisterObraComponent } from './backoffice/components/register-obra/register-obra.component';
import { SignUpPageComponent } from './backoffice/components/sign-up-page/sign-up-page.component';


const routes: Routes = [
  {
    path: '',
    component: IndexSmoosComponent
  },
  {
    path: 'login',
    component: LoginPageComponent
  },
  {
    path: 'sign-up',
    component: SignUpPageComponent
  },
  {
    path: 'register-artist',
    component: RegisterArtistComponent
  },
  {
    path: 'register-obra',
    component: RegisterObraComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
