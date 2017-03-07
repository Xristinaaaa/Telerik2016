import { Pipe, PipeTransform } from '@angular/core'
import { Movie } from '../models/Movie'

@Pipe({
    name: 'order'
})
export class OrderPipe implements PipeTransform{
    transform(movies: Movie[], options: any[]): any[]{
        if(movies && options)
        {
            return movies.sort((a,b) => {
                switch(options[0]){
                    case 'Asc':
                        return options[1] > 0 ? +a.imdbRating - +b.imdbRating : +b.imdbRating - +a.imdbRating;
                    case 'Desc':
                        return options[1] > 0 ? +b.imdbRating - +a.imdbRating : +a.imdbRating - +b.imdbRating;                        
                }
            });
        } else {
            return movies;
        }
    }
}