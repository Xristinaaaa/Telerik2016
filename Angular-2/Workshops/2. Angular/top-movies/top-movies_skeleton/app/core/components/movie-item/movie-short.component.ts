import { Component, Input} from '@angular/core';

import { Movie } from '../../models/Movie';

@Component({
    selector: '[mvdb-movie-short]',
    templateUrl: './movie-short.component.html',
    styleUrls: ['./movie-short.component.css']
})
export class MovieShortComponent{
    @Input() movie: Movie;

    get title(): string {
        return this.movie.Title;
    }

    get poster():string{
        return this.movie.Poster;
    }

    get year():string{
        return this.movie.Year;
    }

    get imdbRating():string{
        return this.movie.imdbRating;
    }
}