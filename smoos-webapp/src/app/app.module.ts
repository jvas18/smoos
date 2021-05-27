import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterObraComponent } from './backoffice/components/register-obra/register-obra.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MultiSelectModule} from 'node_modules/primeng/multiselect';
import {PasswordModule} from 'node_modules/primeng/password';
import { DropdownModule } from 'primeng/dropdown';
import { RegisterArtistComponent } from './backoffice/components/register-artist/register-artist.component';
import { HeaderComponent } from './shared/header/header.component';
import { CalendarModule } from 'primeng/calendar';
import { RadioButtonModule } from 'primeng/radiobutton';
import { IndexSmoosComponent } from './backoffice/components/index-smoos/index-smoos.component';
import { LoginPageComponent } from './backoffice/components/login-page/login-page.component';
import { SignUpPageComponent } from './backoffice/components/sign-up-page/sign-up-page.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterMovieComponent } from './backoffice/components/register-obra/register-movie/register-movie.component';
import { RegisterBookComponent } from './backoffice/components/register-obra/register-book/register-book.component';
import { HomepageUserComponent } from './backoffice/components/homepage-user/homepage-user.component';
import { HeaderUserComponent } from './shared/header-user/header-user.component';
import { SuggestionsUserComponent } from './backoffice/components/suggestions-user/suggestions-user.component';
import { RegisterAlbumComponent } from './backoffice/components/register-obra/register-album/register-album.component';
import { RegisterSongComponent } from './backoffice/components/register-obra/register-song/register-song.component';
import { MovieDetailsComponent } from './backoffice/components/movie-details/movie-details.component';
import { BookDetailsComponent } from './backoffice/components/book-details/book-details.component';
import { SongDetailsComponent } from './backoffice/components/song-details/song-details.component';
import { AlbumDetailsComponent } from './backoffice/components/album-details/album-details.component';
import { RatingModule } from 'primeng/rating';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    RegisterObraComponent,
    IndexSmoosComponent,
    LoginPageComponent,
    SignUpPageComponent,
    RegisterArtistComponent,
    HeaderComponent,
    RegisterMovieComponent,
    RegisterBookComponent,
    HomepageUserComponent,
    HeaderUserComponent,
    SuggestionsUserComponent,
    RegisterAlbumComponent,
    RegisterSongComponent,
    MovieDetailsComponent,
    BookDetailsComponent,
    SongDetailsComponent,
    AlbumDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    PasswordModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatIconModule,
    DropdownModule,
    MultiSelectModule,
    CalendarModule,
    RadioButtonModule,
    RatingModule,
    CommonModule,
    ToastrModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
