using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Db.Model
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public String CourseName { get; set; }
        public CourseDto()
        {

        }
        private CourseDto(ILazyLoader lazyLoader)
        {
            lazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }
        private ICollection<StudentDto> _students;
        public ICollection<StudentDto> Students
        {
            get => LazyLoader.Load(this, ref _students);
            set => _students = value;
        }
    }
}
