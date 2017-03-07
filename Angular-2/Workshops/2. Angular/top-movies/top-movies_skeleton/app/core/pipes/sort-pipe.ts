import { Pipe, PipeTransform } from '@angular/core'
import { Movie } from '../models/Movie'

@Pipe({
    name: 'sort'
})
export class SortPipe implements PipeTransform{
    transform(movies: Movie[], options: any[]): any[]{
        if(movies && options){
            return movies.sort((a,b) => {
                switch(options[0]){
                    case 'Title':
                        return options[1] > 0 ? a.Title.localeCompare(b.Title) : b.Title.localeCompare(a.Title);
                    case 'Rating':
                        return options[1] > 0 ? +a.imdbRating - +b.imdbRating : +b.imdbRating - +a.imdbRating;
                    case 'Year':
                        return options[1] > 0 ? +a.Year - +b.Year : +b.Year - +a.Year;
                }
            });
        } else {
            return movies.sort();
        }
    }
}