using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitConversionCodeAlong
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        internal static Person ConvertStringToPerson(string personString)
        {
            string[] personStrArr = personString.Split(';');
            if(personStrArr.Length != 3)
                return null;

            return new Person
            {
                FirstName = personStrArr[0],
                LastName = personStrArr[1],
                Age = int.Parse(personStrArr[2])
            };
        }

        public static implicit operator Person (string personString)
        {
            string[] personStrArr = personString.Split(';');
            if (personStrArr.Length != 3)
                return null;

            return new Person
            {
                FirstName = personStrArr[0],
                LastName = personStrArr[1],
                Age = int.Parse(personStrArr[2])
            };
        }

        public static string ConvertPersonToString(Person p)
        {
            return $"{p.FirstName};{p.LastName};{p.Age}";
        }

        public static implicit operator string (Person p)
        {
            return $"{p.FirstName};{p.LastName};{p.Age}";
        }
    }
}
