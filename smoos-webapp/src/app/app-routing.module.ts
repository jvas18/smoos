import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterArtistComponent } from './backoffice/components/register-artist/register-artist.component';
import { RegisterObraComponent } from './backoffice/components/register-obra/register-obra.component';
import { IndexSmoosComponent } from './index-smoos/index-smoos.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignUpPageComponent } from './sign-up-page/sign-up-page.component';

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
