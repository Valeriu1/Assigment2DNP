using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assigment3WebApiDatabase.Models;
using Assigment3WebApiDatabase.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Assigment3WebApiDatabase.Data
{
    public class PersonsService : IPersonsService
    {
        private PersonDBContext ctx;


        public PersonsService(PersonDBContext ctx)
        {
            this.ctx = ctx;
        }

       

        public async Task SaveChanges()
        {
            await ctx.SaveChangesAsync();
        }

        public async Task<IList<Adult>> GetPersonsAsync()
        {
            List<Adult> tmp = ctx.Adults.Include(u => u.JobTitle).ToList();
            Console.WriteLine("Triggered getAll");
            return tmp;
        }

        public async Task<Adult> AddPersonAsync(Adult adult)
        {
            ctx.Adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task RemovePersonAsync(int personId)
        {
            Adult toRemove = ctx.Adults.First(t => t.Id == personId);
            Job jobToRemove = ctx.Jobs.First(t => t.Id == personId);
            ctx.Adults.Remove(toRemove);
            ctx.Jobs.Remove(jobToRemove);
            SaveChanges();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate =  ctx.Adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.JobTitle = adult.JobTitle;
            toUpdate.Age = adult.Age;
            toUpdate.Height = adult.Height;
            toUpdate.Sex = adult.Sex;
            toUpdate.Weight = adult.Weight;
            ctx.Update(toUpdate);
            //Fields to update
            SaveChanges();
            return toUpdate;
        }

        public async Task<Adult> GetAsync(int id)
        {
            return ctx.Adults.Include(u=>u.JobTitle).FirstOrDefault(t => t.Id == id);
        }
    }
}