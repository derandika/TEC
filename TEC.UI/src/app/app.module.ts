import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoursesListComponent } from './components/courses/courses-list/courses-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddCourseComponent } from './components/courses/add-course/add-course.component';
import { FormsModule } from '@angular/forms';
import { EditCourseComponent } from './components/courses/edit-course/edit-course.component';

@NgModule({
  declarations: [
    AppComponent,
    CoursesListComponent,
    AddCourseComponent,
    EditCourseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
