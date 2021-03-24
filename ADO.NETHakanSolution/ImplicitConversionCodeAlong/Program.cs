using System;

namespace ImplicitConversionCodeAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            Person moi = Person.ConvertStringToPerson("Strumpan;Psson;33");
            Person p = "Pontus;Wittenmark;42";
            string s = moi;
            //Person y = true;
        }
    }
}
