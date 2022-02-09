using System;
using System.Collections.Generic;
using System.Text;
using University.Contract.Dto;
using University.Db.Model;

namespace University.Contract.Interface
{
    public interface ICourseService
    {
        public void addCourse(CourseDto courseDto);
        public void delCourse(CourseDto courseDto);
        public void updateCourse(CourseDto courseDto);
        public void readCourse(CourseDto courseDto);
        public List<CourseDto> GetCourses();
    }
}
