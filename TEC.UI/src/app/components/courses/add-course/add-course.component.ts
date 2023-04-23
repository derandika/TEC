import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { CoursesService } from 'src/app/services/courses.service';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent implements OnInit {

  addCourseRequest: Course = {
    id: 0,
    title: '',
    description: '',
    startDate: new Date()
  }
  constructor(private courseService: CoursesService, private router: Router) { }

  ngOnInit(): void {
  }

  addCourse(){
    this.courseService.addCourse(this.addCourseRequest)
    .subscribe({
      next: (course) =>{
        this.router.navigate(['courses'])
      }
    })
  }

}
