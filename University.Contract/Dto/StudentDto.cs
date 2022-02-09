using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using University.Contract.Dto;

namespace University.Db.Model
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public StudentDto()
        {

        }
        private StudentDto(ILazyLoader lazyLoader)
        {
            lazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }
        private CourseDto _course;
        public CourseDto course
        {
            get => LazyLoader.Load(this, ref _course);
            set => _course = value;
        }

    }
}
