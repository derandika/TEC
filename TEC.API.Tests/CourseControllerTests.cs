using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.API.Controllers;
using TEC.Domain.Dtos;
using TEC.Domain.Models;
using TEC.Repository.Interface;
using Xunit;

namespace TEC.API.Tests
{
    public class CourseControllerTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private CourseController _CourseController;
        private IMapper _mapper;

        public CourseControllerTests()
        {
            // arrange 
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDto>();
                cfg.CreateMap<CourseCreateDto, Course>();
                cfg.CreateMap<CourseUpdateDto, Course>();
            });

            _mapper = config.CreateMapper();

            _CourseController = new CourseController(new Mock<ILogger<CourseController>>().Object,
                _mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async void GetCoursesReturnsOkResponse()
        {
            // arrange 
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.Get(It.IsAny<int>()))
                .Returns(new Course() { Id = 1, Title = "Test Title", Description = "Test Desciption", StartDate = new DateTime(2023, 04, 21) });


            // act 
            var result = await _CourseController.GetCourse(1);


            //assert 
            var Course = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(1, Assert.IsType<CourseDto>(Course.Value).Id);
        }

        [Fact]
        public async void GetCoursesReturnsAllCourses()
        {
            // arrange 
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.GetAll())
                .Returns(new List<Course>() {
                    new Course() { Id = 1, Title = "Test Title", Description = "Test Desciption", StartDate = new DateTime(2023, 04, 21) },
                    new Course() { Id = 2, Title = "Test Title 1", Description = "Test Desciption 1", StartDate = new DateTime(2023, 04, 20)} });

            // act 
            var result = await _CourseController.GetAll() as OkObjectResult;


            //assert 
            var Courses = Assert.IsType<List<CourseDto>>(result.Value);

            Assert.Equal(2, Courses.Count);
        }

        [Fact]
        public async void GetCoursesByIdReturnsNotFoundResult()
        {
            // arrange 
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.Get(It.IsAny<int>()))
               .Returns(value: null);

            // act 
            var result = await _CourseController.GetCourse(1);

            //assert 
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async void AddCourseReturnsCreatedResponse()
        {
            // arrange 
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.Add(It.IsAny<Course>()));

            // act 
            var result = await _CourseController.CreateCourse(new CourseCreateDto() 
            { Title = "Test Title", Description = "Test Desciption", StartDate = new DateTime(2023, 04, 21) });

            //assert 
            Assert.IsType<CreatedAtActionResult>(result);

        }

        [Fact]
        public async void UpdateCourseReturnsNoContentResponse()
        {
            // arrange 
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.Get(It.IsAny<int>()))
                .Returns(new Course() 
                { Id = 1, Title = "Test Title", Description = "Test Desciption", StartDate = new DateTime(2023, 04, 21) });
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.Update(It.IsAny<Course>()));

            // act 
            var result = await _CourseController.UpdateCourse(1, new CourseUpdateDto() 
            { Title = "Test Title 1", Description = "Test Description 1", StartDate = new DateTime(2023, 04, 21) });

            //assert 
            Assert.IsType<NoContentResult>(result);

        }

        [Fact]
        public async void DeleteCourseReturnsNoContentResponse()
        {
            // arrange 
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.Get(It.IsAny<int>()))
                .Returns(new Course() { Id = 1, Title = "Test Title", Description = "Test Description", StartDate = new DateTime(2023, 04, 21) });
            _mockUnitOfWork.Setup(repo => repo.CourseRepository.Remove(It.IsAny<Course>()));


            // act 
            var result = await _CourseController.DeleteCourse(1);

            //assert 
            Assert.IsType<NoContentResult>(result);

        }
    }
}
