import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { allGenres } from 'src/app/shared/enums/Song-genre.enum';
import {RadioButtonModule} from 'primeng/radiobutton';
import { AlbumService } from 'src/app/backoffice/services/album.service';
import { SongService } from 'src/app/backoffice/services/songs.service';
import { AppService } from 'src/app/backoffice/services/app.service';
import { ArtistService } from 'src/app/backoffice/services/artist.service';

@Component({
  selector: 'app-register-song',
  templateUrl: './register-song.component.html',
  styleUrls: ['./register-song.component.css']
})
export class RegisterSongComponent implements OnInit {

  constructor(private albumService: AlbumService,
              private appService: AppService,
              private artistService: ArtistService,
              private songService: SongService) { }

  genres = allGenres();
  artists = [];
  albums = [];
  pertenceAlbum: string;

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    releaseYear: new FormControl('', [Validators.required]),
    artistId: new FormControl('', Validators.required),
    duration: new FormControl('', Validators.required),
    genres: new FormControl('', Validators.required),
    albumId: new FormControl(''),
    poster: new FormGroup({
      buffer: new FormControl(),
      name: new FormControl(),
      contentType: new FormControl()
    }),
    posterUrl: new FormControl()
  });

  ngOnInit(): void {
    this.albumService.getAll()
    .subscribe((resp)=>{
      this.albums = resp;
    });
    this.artistService.getAll()
    .pipe(
    ).subscribe(resp => {
      this.artists = resp;
    });
  }
  onAttachment($event, formGroup: any, image: any) {
    if (image.length === 0) return;

    var reader = new FileReader();
    reader.readAsDataURL(image[0]);
    reader.onload = (_event) => {
      this.form.get('posterUrl').setValue(reader.result);
    }

    this.appService.onFileChange($event, formGroup);
  }
  save(){
    this.songService.create(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Música cadastrada', 'Sucesso');
    });

  }


}
