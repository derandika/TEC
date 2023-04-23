import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../models/course';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  baseApiUrl: string = environment.baseApi;

  constructor(private http: HttpClient) {}

  getAllCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.baseApiUrl + '/api/course');
  }

  addCourse(addCourseRequest: Course): Observable<Course> {
    return this.http.post<Course>(
      this.baseApiUrl + '/api/course',
      addCourseRequest
    );
  }

  getCourse(id: number): Observable<Course> {
    return this.http.get<Course>(this.baseApiUrl + '/api/course/' + id);
  }

  updateCourse(id: number, updateCourseRequest: Course): Observable<Course> {
    return this.http.put<Course>(
      this.baseApiUrl + '/api/course/' + id,
      updateCourseRequest
    );
  }

  deleteCourse(id: number): Observable<Course> {
    return this.http.delete<Course>(
      this.baseApiUrl + '/api/course/' + id);
  }
}
