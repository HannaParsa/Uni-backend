using Mapster;
using System;
using System.Linq;
using NLog;
using University.Contract.Dto;
using University.Contract.Interface;
using University.Db;
using University.Db.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace University.Service
{
    public class AdmineService : IAdmineService
    {
        private readonly ILogger<AdmineService> _Logger;
        public AdmineService(ILogger<AdmineService> logger)
        {
            _Logger = logger;
        }
        public AdmineService()
        {

        }
        public void addAdmine(AdmineDto admineDto)
        {
            using (var context = new UniversityDbContext())
            {
                _Logger.LogInformation("admine in adding");
                var aa = admineDto.Adapt<Admine>();
                context.Admines.Add(aa);
                context.SaveChanges();
            }
            
        }

        public void delAdmine(AdmineDto admineDto)
        {
            using (var context = new UniversityDbContext())
            {
                var aa = admineDto.Adapt<Admine>();
                context.Admines.Remove(aa);
                context.SaveChanges();
            }
        }

        public void readAdmine(AdmineDto admineDto)
        {
            using (var context = new UniversityDbContext())
            {
                var admine = context.Set<Admine>().Where(a => a.AdmineName.Equals(admineDto.AdmineName)).FirstOrDefault();
                var ss = admine.Adapt<AdmineDto>();
                Console.WriteLine("admine id : {0}, admine name: {1} ", ss.AdmineId, ss.AdmineName);
                context.SaveChanges();
            }
        }

        public void updateAdmine(AdmineDto admineDto)
        {
            using (var context = new UniversityDbContext())
            {
                var aa = admineDto.Adapt<Admine>();
                context.Admines.Update(aa);
            }
        }
         public List<AdmineDto> GetAdmines()
        {
            using (var context = new UniversityDbContext())
            {
                var admines = context.Set<Admine>();
                var list =admines.Adapt<List<AdmineDto>>();
                string s = JsonConvert.SerializeObject(list);
                Console.WriteLine(s);
            }
            return null;
        }
    }
}
