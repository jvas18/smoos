import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AlbumService } from 'src/app/backoffice/services/album.service';
import { AppService } from 'src/app/backoffice/services/app.service';
import { ArtistService } from 'src/app/backoffice/services/artist.service';
import { allGenres } from 'src/app/shared/enums/Song-genre.enum';

@Component({
  selector: 'app-register-album',
  templateUrl: './register-album.component.html',
  styleUrls: ['./register-album.component.css']
})
export class RegisterAlbumComponent implements OnInit {

  constructor(private appService: AppService,
              private artistService: ArtistService,
              private albumService: AlbumService ) { }

  genres = allGenres();
  artists = [];

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    releaseYear: new FormControl('', [Validators.required]),
    artistId: new FormControl('', Validators.required),
    duration: new FormControl('', Validators.required),
    genres: new FormControl('', Validators.required),
    poster: new FormGroup({
      buffer: new FormControl(),
      name: new FormControl(),
      contentType: new FormControl()
    }),
    posterUrl: new FormControl()
  });

  ngOnInit(): void {
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
    debugger;
    this.albumService.create(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Album cadastrado', 'Sucesso');
    });

  }
}
