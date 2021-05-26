import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ArtistService } from 'src/app/backoffice/services/artist.service';
import { BookService } from 'src/app/backoffice/services/book.service';
import { allGenres } from 'src/app/shared/enums/book-genre.enum';

@Component({
  selector: 'app-register-book',
  templateUrl: './register-book.component.html',
  styleUrls: ['./register-book.component.css']
})
export class RegisterBookComponent implements OnInit {

  
  constructor(private bookService: BookService,
              private artistService: ArtistService) { }
  genres = allGenres();
  artists = [];

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    releaseYear: new FormControl('', [Validators.required]),
    author: new FormControl('', Validators.required),
    pages: new FormControl('', Validators.required),
    summary: new FormControl('', Validators.required),
    genres: new FormControl('', Validators.required),
    publisher: new FormControl('', Validators.required)
  });

  ngOnInit(): void {
    this.artistService.getAll()
    .pipe(
    ).subscribe(resp => {
      this.artists = resp;
    });
  }
  save(){

    this.bookService.create(this.form.value).pipe(
    ).subscribe(resp => {
    });

  }

}
