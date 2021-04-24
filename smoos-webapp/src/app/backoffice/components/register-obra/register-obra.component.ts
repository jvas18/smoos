import { Component, OnInit } from '@angular/core';
import {
  trigger,
  state,
  style,
  transition,
  animate
} from "@angular/animations";
import { SelectItem, PrimeNGConfig } from "primeng/api";

interface Genre {
  name: string,
  code: string
}

@Component({
  selector: 'app-register-obra',
  templateUrl: './register-obra.component.html',
  styleUrls: ['./register-obra.component.css']
})
export class RegisterObraComponent implements OnInit {

  date1: Date;
  pertenceAlbum: string;

  selectedGenres: string[] = [];
  genres: any[];

  constructor(private primengConfig: PrimeNGConfig) {

    this.genres = [
      { genre: "Ação", code: "action" },
      { genre: "Aventura", code: "adventure" },
      { genre: "Fantasia", code: "fantasy" },
      { genre: "Sci-fi", code: "scifi" },
      { genre: "Drama", code: "drama" },
      { genre: "Biografia", code: "biography" },
      { genre: "Romance", code: "romance" },
      { genre: "Musical", code: "musical" },
      { genre: "Comédia", code: "comedy" },
      { genre: "Terror", code: "horror" },
      { genre: "Comédia romântica", code: "romcom" }
    ];

  }

  ngOnInit(): void {
    this.primengConfig.ripple = true;
  }

}
