using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Start
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human[] humans = new Human[] {
                new Human("Oleg","Programmer", 30),
                new Human("Nikita","Director",27),
                new Human("Ilya","Programmer", 33),
                new Human("Ivan","Developer", 23),
                new Human("Kristina","Manager",25)
            };
            var result = from human in humans where human.Age > 25 select human;
            foreach (Human h in result)
            {
                Console.WriteLine("Name: {0} \nJob:{1} \nAge:{2}\n", h.Name,h.Description,h.Age);
            }           
            Console.WriteLine("---------------------------------------------------\n");
            var result2 = humans.Where(human => human.Age > 25).OrderBy(human => human.Name.Length);
            foreach (Human h in result2)
            {
                Console.WriteLine("Name: {0} \nJob:{1} \nAge:{2}\n", h.Name, h.Description, h.Age);
            }
            Console.WriteLine("---------------------------------------------------\n");
            TestLambda();
            Console.WriteLine("---------------------------------------------------\n");
            var result3 = from human in humans where human.Age > 25 orderby human.Age ascending select human;
            foreach (Human h in result3)
            {
                Console.WriteLine(h.ToString());
            }
            Console.WriteLine("---------------------------------------------------\n");

            var result4 = from human in humans where human.Age > 25 orderby human.Age ascending select new { human.Name, human.Description };
            foreach (var h in result4)
            {
                Console.WriteLine(h.Name + " " +  h.Description);
            }
            Console.WriteLine("---------------------------------------------------\n");

            var result5 = from human in humans where human.Age > 25 orderby human.Age ascending select new Human (human.Name, human.Description, human.Age);
            foreach (var h in result5)
            {
                Console.WriteLine(h);
            }
            Console.WriteLine("---------------------------------------------------\n");
            Console.ReadLine();
        }
        delegate int del(int i);
        static void TestLambda()
        {
            del myDelegate = (x) => x * x;
            int sq = myDelegate(5); //sq = 25
            Console.WriteLine(sq);
        }
    }
    class Human
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public Human(string name, string description, int age) 
        {
            Name = name;
            Description = description;
            Age = age;
        }
        public override string ToString()
        {
            return Name + Description + Age.ToString();
        }
    }
}
