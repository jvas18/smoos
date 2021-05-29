import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../../services/album.service';
import { BookService } from '../../services/book.service';
import { MovieService } from '../../services/movie.service';
import { SongService } from '../../services/songs.service';

@Component({
  selector: 'app-homepage-user',
  templateUrl: './homepage-user.component.html',
  styleUrls: ['./homepage-user.component.css', './homepage-user.component.scss']
})
export class HomepageUserComponent implements OnInit {

  constructor(private movieService: MovieService,
              private bookService: BookService,
              private songService: SongService,
              private albumService: AlbumService)
   { }

   movies = [];
   books = [];
   albums = [];
   songs = [];
  ngOnInit(): void {
    this.movieService.getAll().subscribe((resp)=>{
      console.log(resp);
      this.movies = resp;
    });
    this.bookService.getAll().subscribe((resp)=>{
      console.log(resp);
      this.books = resp;
    });
    this.albumService.getAll().subscribe((resp)=>{
      console.log(resp);
      this.albums = resp;
    });
    this.songService.getAll().subscribe((resp)=>{
      console.log(resp);
      this.songs = resp;
    });
  }

}
