import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AppService } from 'src/app/backoffice/services/app.service';
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
              private appService: AppService,
              private artistService: ArtistService) { }
  genres = allGenres();
  artists = [];

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    releaseYear: new FormControl('', [Validators.required]),
    artistId: new FormControl('', Validators.required),
    pages: new FormControl('', Validators.required),
    summary: new FormControl('', Validators.required),
    genres: new FormControl('', Validators.required),
    publisher: new FormControl('', Validators.required),
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
    this.bookService.create(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Livro cadastrado', 'Sucesso');
    });

  }

}
