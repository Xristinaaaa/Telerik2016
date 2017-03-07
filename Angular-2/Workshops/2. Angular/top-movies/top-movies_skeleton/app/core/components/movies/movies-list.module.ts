import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import * as Movies from './index';
import { SortPipe } from '../../pipes/sort-pipe'
import { OrderPipe } from '../../pipes/order-pipe'
import { FilterPipe } from '../../pipes/filter-pipe'

import { MovieService } from '../../services/movie-service'
import { MovieShortModule } from '../movie-item/movie-short.module';

@NgModule({
    imports: [CommonModule, FormsModule, MovieShortModule ],
    declarations: [ Movies.MoviesListComponent, SortPipe, OrderPipe, FilterPipe ],
    exports: [ Movies.MoviesListComponent ],
    providers: [ SortPipe, OrderPipe, FilterPipe, MovieService ]
})
export class MovieListModule {}