import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';
import { ArtistService } from 'src/app/backoffice/services/artist.service';
import { MovieService } from 'src/app/backoffice/services/movie.service';
import { allGenres } from 'src/app/shared/enums/movie-genre.enum';

@Component({
  selector: 'app-register-movie',
  templateUrl: './register-movie.component.html',
  styleUrls: ['./register-movie.component.css']
})
export class RegisterMovieComponent implements OnInit {

  constructor(private movieService: MovieService,
              private artistService: ArtistService) { }


  genres = allGenres();
  artists = [];

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    releaseYear: new FormControl('', [Validators.required]),
    genres: new FormControl('', Validators.required),
    duration: new FormControl('', Validators.required),
    summary: new FormControl('', Validators.required),
    actors: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required)
  });
  ngOnInit(): void {
    this.artistService.getAll()
    .pipe(
    ).subscribe(resp => {
      this.artists = resp;
    });

  }
  save(){

    this.movieService.create(this.form.value).pipe(
    ).subscribe(resp => {
    });

  }


}
