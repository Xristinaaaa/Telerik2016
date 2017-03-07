import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';

import * as Movie from './index';

@NgModule({
    imports: [CommonModule],
    declarations: [ Movie.MovieShortComponent ],
    exports: [ Movie.MovieShortComponent ]
})
export class MovieShortModule {}