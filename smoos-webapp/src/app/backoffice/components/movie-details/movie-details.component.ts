import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppService } from '../../services/app.service';
import { MovieService } from '../../services/movie.service';
import { RatingService } from '../../services/rating.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  constructor(private movieService: MovieService,
              private appService: AppService,
              private actRoute: ActivatedRoute,
              private ratingSevice: RatingService,
              private ratingService: RatingService) { }

  movieId;
  movie;

  option: string;
  val: number;

  form = new FormGroup({
    title: new FormControl('', [Validators.required]),
    comment: new FormControl('', [Validators.required]),
    stars: new FormControl('', Validators.required),
    userId: new FormControl(),
    movieId: new FormControl()
  });
  ratings = [];
  ngOnInit(): void {
    this.movieId = this.actRoute.snapshot.params.id;
    this.movieService.get(this.movieId).
    subscribe((resp)=>{
      console.log(resp);
      this.movie = resp;
    });
    this.ratingService.getMovies(this.movieId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });
  }
  save(){
    const userId = this.appService.sessionUser.id;
    this.form.patchValue({userId, movieId: this.movieId});
    this.ratingService.createMovie(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Avaliação Enviada', 'Sucesso');
    });
    this.ratingService.getMovies(this.movieId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });

  }

  favoriteWork(){
    this.option = 'favorited-heart';
  }
}
