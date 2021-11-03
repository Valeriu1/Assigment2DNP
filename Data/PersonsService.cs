using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assigment2WebApi.Data
{
    public class PersonsService : IPersonsService
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public PersonsService()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(adultsFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            // string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            // {
            //     WriteIndented = true
            // });
            // using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            // {
            //     outputFile.Write(jsonFamilies);
            // }

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public async Task<IList<Adult>> GetPersonsAsync()
        {
            List<Adult> tmp = new List<Adult>(Adults);
            Console.WriteLine("Triggered getAll");
            return tmp;
        }

        public async Task<Adult> AddPersonAsync(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task RemovePersonAsync(int personId)
        {
            Adult toRemove = Adults.First(t => t.Id == personId);
            Adults.Remove(toRemove);
            SaveChanges();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate = Adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.JobTitle = adult.JobTitle;
            toUpdate.Age = adult.Age;
            toUpdate.Height = adult.Height;
            toUpdate.Sex = adult.Sex;
            toUpdate.Weight = adult.Weight;
            //Fields to update
            SaveChanges();
            return toUpdate;
        }

        public async Task<Adult> GetAsync(int id)
        {
            return Adults.FirstOrDefault(t => t.Id == id);
        }
    }
}