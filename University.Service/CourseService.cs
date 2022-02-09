using Mapster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.Contract.Dto;
using University.Contract.Interface;
using University.Db;
using University.Db.Model;

namespace University.Service
{
    public class CourseService : ICourseService
    {
        public void addCourse(CourseDto courseDto)
        {
            using (var context = new UniversityDbContext())
            {
                var cc = courseDto.Adapt<Course>();
                context.Courses.Add(cc);
                context.SaveChanges();
            }
        }

        public void delCourse(CourseDto courseDto)
        {
            using (var context = new UniversityDbContext())
            {
                var cc = courseDto.Adapt<Course>();
                context.Courses.Remove(cc);
                context.SaveChanges();
            }
        }

        public void readCourse(CourseDto courseDto)
        {
            using (var context = new UniversityDbContext())
            {
                var course = context.Set<Course>().Where(a => a.CourseName.Equals(courseDto.CourseName)).FirstOrDefault();
                var ss = course.Adapt<CourseDto>();
                Console.WriteLine("course id : {0}, course name: {1} ", ss.CourseId, ss.CourseName);
            }
        }

        public void updateCourse(CourseDto courseDto)
        {
            using (var context = new UniversityDbContext())
            {
                var cc = courseDto.Adapt<Course>();
                context.Courses.Update(cc);
                context.SaveChanges();
            }
        }
        public List<CourseDto> GetCourses()
        {
            using (var context = new UniversityDbContext())
            {
                var courses = context.Set<Course>();
                var list = courses.Adapt<List<ProfessorDto>>();
                string s = JsonConvert.SerializeObject(list);
                Console.WriteLine(s);
            }
            return null;
        }
    }
}
