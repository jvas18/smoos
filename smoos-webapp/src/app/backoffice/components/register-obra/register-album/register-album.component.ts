import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { allGenres } from 'src/app/shared/enums/Song-genre.enum';

@Component({
  selector: 'app-register-album',
  templateUrl: './register-album.component.html',
  styleUrls: ['./register-album.component.css']
})
export class RegisterAlbumComponent implements OnInit {

  constructor() { }

  genres = allGenres();
  artists = [];

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    releaseYear: new FormControl('', [Validators.required]),
    singer: new FormControl('', Validators.required),
    duration: new FormControl('', Validators.required),
    genres: new FormControl('', Validators.required)
  });

  ngOnInit(): void {
  }

}
