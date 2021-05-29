import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AlbumService } from '../../services/album.service';
import { AppService } from '../../services/app.service';
import { RatingService } from '../../services/rating.service';

@Component({
  selector: 'app-album-details',
  templateUrl: './album-details.component.html',
  styleUrls: ['./album-details.component.css']
})
export class AlbumDetailsComponent implements OnInit {

  constructor( private actRoute: ActivatedRoute,
               private albumService: AlbumService,
               private ratingService: RatingService,
               private appService: AppService) { }

  option: string;
  val: number;

  album;
  albumId;
  form = new FormGroup({
    title: new FormControl('', [Validators.required]),
    comment: new FormControl('', [Validators.required]),
    stars: new FormControl('', Validators.required),
    userId: new FormControl(),
    albumId: new FormControl()
  });
  ratings= [];
  ngOnInit(): void {
    this.albumId = this.actRoute.snapshot.params.id;
    this.albumService.get(this.albumId).
    subscribe((resp)=>{
      console.log(resp);
      this.album = resp;
    });
    this.ratingService.getAlbum(this.albumId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });
    
  }

  save(){
    const userId = this.appService.sessionUser.id;
    this.form.patchValue({userId, albumId: this.albumId});
    this.ratingService.createAlbum(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Avaliação Enviada', 'Sucesso');
    });
    this.ratingService.getAlbum(this.albumId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });

  }
  favoriteWork(){
    this.option = 'favorited-heart';
  }
}
