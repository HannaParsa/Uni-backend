using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System;
using University.Contract.Dto;
using University.Db.Model;
using University.Service;

namespace University
{
    public class Program
    {
        //private static readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            //var temp = 1;
            //logger.Info($"abcd {temp}");
            CourseDto course1 = new CourseDto() { CourseName = "course1" };
            StudentDto student1 = new StudentDto() { StudentName = "student1", course = course1 };
            StudentDto student2 = new StudentDto() { StudentName = "student2" };
            StudentDto student3 = new StudentDto() { StudentName = "student3" };
            StudentService studentService = new StudentService();
            CourseService courseService = new CourseService();
            AdmineDto admine1 = new AdmineDto() { AdmineName = "admine1" };
            ProfessorService professorService = new ProfessorService(); 
            AdmineService admineService = new AdmineService();
            //build
            var config = new ConfigurationBuilder()
          .SetBasePath(System.IO.Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .Build();

            var servicesProvider = BuildDi(config);

            using (servicesProvider as IDisposable)
            {
                var admin = servicesProvider.GetRequiredService<AdmineService>();

                //admin.addAdmine(admine1);
                Console.WriteLine("test nlog");
            }
            //admineService.addAdmine(admine1);
            //courseService.addCourse(course1);
            //studentService.AddStudent(student1);
            //studentService.readStudent(student1);
            //studentService.AddStudent(student2);
            //studentService.readStudent(student2);
            //studentService.AddStudent(student3);
            //studentService.readStudent(student3);
            //studentService.updateStudent(student1);
            //studentService.dellStudent(student1);
            //courseService.delCourse(course1);
            //studentService.GetStudents();
            LogManager.Shutdown();
        }
        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
              
               .AddTransient<AdmineService>()
               .AddLogging(loggingBuilder =>
               {
                   loggingBuilder.ClearProviders();
                   loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                   loggingBuilder.AddNLog(config);
               })
               .BuildServiceProvider();

        }
    }
}
