using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Colour
    {
        public float r, g, b;
    }

    class Dog
    {
        public string name;
        public int size;
        public string breed;
        public ConsoleColor colour;

        public void Walk()
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(name + " is walking.");
            Console.ReadLine();
        }

        public void Eat(string food)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(name + " is eating" + food);
            Console.ReadLine();
        }

        public void Shit()
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(name + " is shitting");
            Console.ReadLine();
        }

        public void Sleep()
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(name + " is sleeping");
            Console.ReadLine();
        }

        public void Wag()
        {
            Console.WriteLine(name + " is wagging its tail");
            Console.ReadLine();
        }

        public void Speak()
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(name + " says: Woof!");
            Console.ReadLine();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            #region Dog 1
            Dog dog1 = new Dog();
            dog1.name = "Fido";
            dog1.size = 5;
            dog1.breed = "Cavoodle";
            dog1.colour = ConsoleColor.Green;

            Dog dog2 = new Dog();
            dog2.name = "Rover";
            dog2.size = 10;
            dog2.breed = "Great Dane";
            dog2.colour = ConsoleColor.Yellow;

            Dog dog3 = new Dog();
            dog3.name = "Spots";
            dog3.size = 7;
            dog3.breed = "Dalmation";
            dog3.colour = ConsoleColor.White;

            dog1.Speak();
            dog2.Speak();
            dog3.Speak();
            dog1.Walk();
            dog1.Eat(" Dog Food");
            dog1.Shit();
            Colour black = new Colour();
            #endregion
        }
    }
}
