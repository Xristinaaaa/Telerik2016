import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Movie } from '../models/Movie';

@Injectable()
export class MovieService {
    constructor(private http: Http) {
    }

    getMovies(): Observable<any> {
        return this.http.get('../../../data/movies.json')
    }
}