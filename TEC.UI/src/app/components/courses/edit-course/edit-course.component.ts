import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { CoursesService } from 'src/app/services/courses.service';

@Component({
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.css'],
})
export class EditCourseComponent implements OnInit {
  courseDetails: Course = {
    id: 0,
    title: '',
    description: '',
    startDate: new Date(),
  };

  constructor(
    private route: ActivatedRoute,
    private courseService: CoursesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = Number(params.get('id'));

        if (id) {
          this.courseService.getCourse(id).subscribe({
            next: (response) => {
              this.courseDetails = response;
              this.courseDetails.startDate = response.startDate
            },
          });
        }
      },
    });
  }

  updateCourse(){
    this.courseService.updateCourse(this.courseDetails.id, this.courseDetails)
    .subscribe({
      next : (response) =>{
        this.router.navigate(['courses'])
      }
    })
  }

  deleteCourse(){
    this.courseService.deleteCourse(this.courseDetails.id)
    .subscribe({
      next : (response) =>{
        this.router.navigate(['courses'])
      }
    })
  }
}
