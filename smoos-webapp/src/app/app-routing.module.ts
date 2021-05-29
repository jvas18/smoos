import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlbumDetailsComponent } from './backoffice/components/album-details/album-details.component';
import { BookDetailsComponent } from './backoffice/components/book-details/book-details.component';
import { HomepageUserComponent } from './backoffice/components/homepage-user/homepage-user.component';
import { IndexSmoosComponent } from './backoffice/components/index-smoos/index-smoos.component';
import { LoginPageComponent } from './backoffice/components/login-page/login-page.component';
import { MovieDetailsComponent } from './backoffice/components/movie-details/movie-details.component';
import { RegisterArtistComponent } from './backoffice/components/register-artist/register-artist.component';
import { RegisterObraComponent } from './backoffice/components/register-obra/register-obra.component';
import { SignUpPageComponent } from './backoffice/components/sign-up-page/sign-up-page.component';
import { SongDetailsComponent } from './backoffice/components/song-details/song-details.component';
import { SuggestionsUserComponent } from './backoffice/components/suggestions-user/suggestions-user.component';


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
  },
  {
    path: 'homepage-user',
    component: HomepageUserComponent
  },
  {
    path: 'suggestion-user',
    component: SuggestionsUserComponent
  },
  {
    path: 'movie-details/:id',
    component: MovieDetailsComponent
  },
  {
    path: 'book-details/:id',
    component: BookDetailsComponent
  },
  {
    path: 'song-details/:id',
    component: SongDetailsComponent
  },
  {
    path: 'album-details/:id',
    component: AlbumDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
