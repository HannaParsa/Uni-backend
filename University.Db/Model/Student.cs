using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Db.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public Student()
        {

        }
        private Student(ILazyLoader lazyLoader )
        {
              lazyLoader = lazyLoader;    
        }
        private ILazyLoader LazyLoader { get; set; }
        private Course _course;
        public Course course
        {
            get => LazyLoader.Load(this, ref _course);
            set => _course = value;
        }

    }
}
