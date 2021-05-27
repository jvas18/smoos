import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { allGenres } from 'src/app/shared/enums/Song-genre.enum';
import {RadioButtonModule} from 'primeng/radiobutton';

@Component({
  selector: 'app-register-song',
  templateUrl: './register-song.component.html',
  styleUrls: ['./register-song.component.css']
})
export class RegisterSongComponent implements OnInit {

  constructor() { }

  genres = allGenres();
  artists = [];
  albums = [];
  pertenceAlbum: string;

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    releaseYear: new FormControl('', [Validators.required]),
    singer: new FormControl('', Validators.required),
    duration: new FormControl('', Validators.required),
    genres: new FormControl('', Validators.required),
    sePertenceAlbum: new FormControl('', Validators.required),
    album: new FormControl('', Validators.required)
  });

  ngOnInit(): void {
  }

}
