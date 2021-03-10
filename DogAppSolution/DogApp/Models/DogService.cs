using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Models
{
    public class DogService
    {
        private static List<Dog> dogList = new List<Dog>();
        private static int dogCounter = 0;
        public void AddDog(Dog dog)
        {
            dog.Id = dogCounter++;
            dogList.Add(dog);
        }

        public Dog[] GetAllDogs()
        {
            return dogList
                .ToArray();
        }

        public Dog GetDogById(int id)
        {
            return dogList
                .Where(o => o.Id == id)
                .Single();
        }

        public void UpdateDog(Dog dog)
        {
            dogList[dog.Id].Name = dog.Name;
            dogList[dog.Id].Age = dog.Age;
        }

        public void DeleteDog(Dog dog)
        {
            
        }
    }
}
