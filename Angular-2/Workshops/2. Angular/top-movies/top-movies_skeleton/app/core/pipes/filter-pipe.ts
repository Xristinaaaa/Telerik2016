import { Pipe, PipeTransform } from '@angular/core'
import { Movie } from '../models/Movie'

@Pipe({
    name: 'filter'
})
export class FilterPipe implements PipeTransform{
    transform(movies: Movie[], filter: string): any[] {
        if (filter) {
            return movies.filter(movie => {
                return movie.Title.toLocaleLowerCase().indexOf(filter) > -1;
            });
        } else {
            return movies;
        }
    }
}