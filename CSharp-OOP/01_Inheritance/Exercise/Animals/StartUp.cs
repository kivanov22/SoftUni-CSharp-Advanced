﻿using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Beast!")
                {
                    break;

                }

                var data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (line == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (line == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (line == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (line == "Tomcat")
                {
                    Tomcat tomCat = new Tomcat(name, age);
                    Console.WriteLine(tomCat);
                    Console.WriteLine(tomCat.ProduceSound());
                }
                else if (line == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }

            }

        }
    }
}
