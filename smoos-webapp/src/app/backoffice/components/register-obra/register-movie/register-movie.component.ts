import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';
import { AppService } from 'src/app/backoffice/services/app.service';
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
              private appService: AppService,
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
    country: new FormControl('', Validators.required),
    poster: new FormGroup({
      buffer: new FormControl(),
      name: new FormControl(),
      contentType: new FormControl()
    }),
    posterUrl: new FormControl()
  });
  onAttachment($event, formGroup: any, image: any) {
    if (image.length === 0) return;

    var reader = new FileReader();
    reader.readAsDataURL(image[0]);
    reader.onload = (_event) => {
      this.form.get('posterUrl').setValue(reader.result);
    }

    this.appService.onFileChange($event, formGroup);
  }
  ngOnInit(): void {
    this.artistService.getAll()
    .pipe(
    ).subscribe(resp => {
      this.artists = resp;
    });

  }
  save(){

    this.movieService.create(this.form.value).subscribe(resp => {
      this.appService.toastr.success('Filme cadastrado', 'Sucesso');
    });
  }


}
