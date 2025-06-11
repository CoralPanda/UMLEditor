using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLEditor.Classes.Underclasses
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public void Greet(Person person)
        {
            Console.WriteLine("Hi," + person.Name);
        }
    }
}
