import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule, Router, Routes} from '@angular/router';

import { AppComponent } from './app.component';

import { MovieListModule } from './core/components/movies/movies-list.module'
import { MovieShortModule } from './core/components/movie-item/movie-short.module'

//import {Ng2BootstrapModule} from 'ng2-bootstrap/ng2-bootstrap';


@NgModule({
    imports:[
        BrowserModule,
        HttpModule,
        MovieListModule,
        MovieShortModule
    ],
    declarations:[AppComponent],
    providers:[],
    bootstrap:[AppComponent]
})
export class AppModule { }
