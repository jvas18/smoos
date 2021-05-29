import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppService } from '../../services/app.service';
import { RatingService } from '../../services/rating.service';
import { SongService } from '../../services/songs.service';

@Component({
  selector: 'app-song-details',
  templateUrl: './song-details.component.html',
  styleUrls: ['./song-details.component.css']
})
export class SongDetailsComponent implements OnInit {

  constructor(private songService: SongService,
              private actRoute: ActivatedRoute,
              private ratingService: RatingService,
              private appService: AppService) { }

  option: string;
  val: number;

  form = new FormGroup({
    title: new FormControl('', [Validators.required]),
    comment: new FormControl('', [Validators.required]),
    stars: new FormControl('', Validators.required),
    userId: new FormControl(),
    songId: new FormControl()
  });

  songId;
  song;
  ratings =[];
  ngOnInit(): void {
    this.songId = this.actRoute.snapshot.params.id;
    this.songService.get(this.songId).
    subscribe((resp)=>{
      console.log(resp);
      this.song = resp;
    });
    this.ratingService.getSong(this.songId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });
  }

  favoriteWork(){
    this.option = 'favorited-heart';
  }
  save(){
    const userId = this.appService.sessionUser.id;
    this.form.patchValue({userId, songId: this.songId});
    this.ratingService.createSong(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Avaliação Enviada', 'Sucesso');
    });
    this.ratingService.getSong(this.songId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });

  }

}
