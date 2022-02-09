using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Db.Model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public String CourseName { get; set; }
        public Course()
        {

        }
        private Course(ILazyLoader lazyLoader)
        {
            lazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }
        private ICollection<Student> _students;
        public ICollection<Student> Students
        {
            get => LazyLoader.Load(this, ref _students);
            set => _students = value;
        }
    }
}
