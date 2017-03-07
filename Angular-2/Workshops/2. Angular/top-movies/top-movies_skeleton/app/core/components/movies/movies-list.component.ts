import {Component, OnInit, Inject} from '@angular/core';
import { Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';

import { Movie } from '../../models/Movie';
import { SortPipe } from '../../pipes/sort-pipe';
import { OrderPipe } from '../../pipes/order-pipe';
import { FilterPipe } from '../../pipes/filter-pipe';

import { MovieService } from '../../services/movie-service';
@Component({
    selector: 'movies-list',
    templateUrl: './movies-list.component.html',
    styleUrls: ['./movie-list.component.css']
})
export class MoviesListComponent implements OnInit{
    private movies: Movie[];

    constructor(private http: Http, private sortPipe: SortPipe, private orderPipe: OrderPipe, private filterPipe: FilterPipe,
            private movieService: MovieService) {
        this.movies=[];
    }

    ngOnInit(){
        this.movieService.getMovies()
            .map((res: Response) => res.json()) 
            .subscribe(movies=> this.movies=movies);
    }
    
    onSort(options: any[]){
        this.sortPipe.transform(this.movies, options);
    }

    onOrder(options: any[]){
        this.orderPipe.transform(this.movies, options);
    }

    onSearch(option: string){
        this.filterPipe.transform(this.movies, option)
    }
}